using OAuth.Provider.DAL;
using OAuth.Provider.Helper;
using OAuth.Provider.Models;
using OAuth.Provider.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OAuth.Provider.Controllers
{
    public class OAuthController : Controller
    {
        private readonly OAuthDbContext db;
        public OAuthController()
        {
            db = new OAuthDbContext();
        }
        /// <summary>
        /// 由第三方网站跳转过来
        /// </summary>
        /// <param name="validateModel">传入ClientId,ReturnUrl,ResponseType</param>
        /// <returns></returns>
        [OAuthAuthorize]
        public ActionResult AccessManager(AccessTempTokenRequest validateModel)
        {
            //TODO:查询Website信息 ： 提示用户某某网站要获取你的授权
            if (validateModel.ResponseType.ToUpper() != "CODE")
            {
                var result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return result;
            }
            var website = db.Websites.SingleOrDefault(w => w.Code == validateModel.ClientId && w.ReturnUrl == validateModel.ReturnUrl);
            if (website == null)
            {
                var result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return result;
            }

            //验证是否绑定过
            var userId = UserSessionModel.GetUserId();
            var exist = db.Tokens.SingleOrDefault(w => w.UserId == userId && w.WebsiteId == website.Id && w.Effective);
            if (exist != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("http://{0}?&OpenId={1}", website.ReturnUrl, exist.OpenId);
                return Redirect(sb.ToString());
            }

            ViewBag.Website = website.Name;
            AccessManagerViewModel viewModel = new AccessManagerViewModel
            {
                WebsiteId = website.Id,
                AccessAccount = true,
                AccessResource = false
            };
            return View(viewModel);
        }

        [OAuthAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccessManager(AccessManagerViewModel viewModel)
        {
            //TODO: 生成OpenId AccessToken 跳转到第三方网站在Url中添加临时Code
            if (ModelState.IsValid)
            {
                var website = db.Websites.Find(viewModel.WebsiteId);
                StringBuilder sb = new StringBuilder();
                var userId = UserSessionModel.GetUserId();
                ///为了使用已经生成但是没有生效的Token行
                var exist = db.Tokens.SingleOrDefault(w => w.UserId == userId && w.WebsiteId == viewModel.WebsiteId);
                if (exist != null)
                {
                    exist.Expire = DateTime.Now.AddYears(1);
                    exist.TempCodeExpire = DateTime.Now.AddMinutes(10);
                    db.Entry<Token>(exist).State = EntityState.Modified;
                    db.SaveChanges();
                    sb.AppendFormat("http://{0}?Code={1}&OpenId={2}", website.ReturnUrl, exist.TempCode, exist.OpenId);
                }
                else
                {
                    Token token = new Token();
                    token.Expire = DateTime.Now.AddYears(1);
                    token.OpenId = Math.Abs(GuidHelper.GuidToLongID());
                    token.WebsiteId = website.Id;
                    token.UserId = UserSessionModel.GetUserId();
                    token.TempCode = GuidHelper.GuidTo16String();
                    token.TempCodeExpire = DateTime.Now.AddMinutes(10);
                    token.RefreshCode = GuidHelper.GuidTo16String();
                    token.AccessToken = GuidHelper.GuidTo16String();
                    token.Scope = viewModel.AccessResource;
                    token.Effective = false;
                    db.Tokens.Add(token);
                    db.SaveChanges();
                    sb.AppendFormat("http://{0}?Code={1}&OpenId={2}", website.ReturnUrl, token.TempCode, token.OpenId);
                }
                return Redirect(sb.ToString());
            }
            return View();
        }
        /// <summary>
        /// 用于第三方网站获取AccessToken和Refresh Token等信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public JsonResult AccessToken(AccessTokenRequest request)
        {
            AccessTokenResponse result = new AccessTokenResponse();
            result.OpenId = request.OpenId;
            var website = db.Websites.SingleOrDefault(t => t.Code == request.ClientId && t.ReturnUrl == request.ReturnUrl);
            if (website == null)
            {
                return Json(new OAuthMessage { Message="ReturnUrl和ClientId不匹配,请确认是否正确或前往SimpleOAuth平台修改"}, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var token = db.Tokens.SingleOrDefault(t => t.OpenId == request.OpenId &&
                    t.TempCode == request.Code && t.WebsiteId == website.Id &&
                    DateTime.Compare(t.TempCodeExpire, DateTime.Now) > 0);//临时Code不能过期
                if (token == null)
                {
                    return Json(new OAuthMessage { Message = "请求的OpenId有误,或则临时Code已过期" }, JsonRequestBehavior.AllowGet);
                }
                token.Effective=true;
                db.Entry<Token>(token).State = EntityState.Modified;
                db.SaveChanges();
                result.AccessToken = token.AccessToken;
                result.Expire = token.Expire;
                result.RefreshCode = token.RefreshCode;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
