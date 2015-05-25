using OAuth.Provider.Helper;
using OAuth.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth.Provider.Controllers
{
    [OAuthAuthorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (UserSessionModel.GetCurrentUser() != null)
                ViewBag.UserName = UserSessionModel.GetCurrentUser().Name;
            else
                ViewBag.UserName = string.Empty;
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult IsLogin()
        {
            if (UserSessionModel.GetCurrentUser() != null)
                ViewBag.UserName = UserSessionModel.GetCurrentUser().Name;
            else
                ViewBag.UserName = string.Empty;
            return PartialView();
        }
    }
}
