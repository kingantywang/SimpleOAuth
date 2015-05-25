using OAuth.Provider.DAL;
using OAuth.Provider.Models;
using OAuth.Provider.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OAuth.Provider.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private OAuthDbContext db;
        public AccountController()
        {
            db = new OAuthDbContext();
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            byte[] bytes = Convert.FromBase64String(returnUrl);
            string realUrl = Encoding.UTF8.GetString(bytes);
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(u => u.Name == viewModel.Name && u.Password == viewModel.Password);
                if (user != null)
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    UserSessionModel sessionModel = new UserSessionModel { Id = user.Id, Name = user.Name };
                    var cookie = new HttpCookie("AccountInfo");
                    cookie.Value = js.Serialize(sessionModel);
                    //cookie.Secure = true;//这个要在SSL下才能生效 否者传不过去
                    cookie.Expires = viewModel.Remember ? DateTime.Now.AddDays(7) : DateTime.Now.AddHours(30);
                    Response.Cookies.Remove("AccountInfo");
                    Response.AppendCookie(cookie);
                    return Redirect(realUrl);
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            var cookie = Request.Cookies["AccountInfo"];
            cookie.Expires = DateTime.Now.AddDays(-2);
            Response.SetCookie(cookie);
            return Redirect("~/Home/Index");
        }

    }
}
