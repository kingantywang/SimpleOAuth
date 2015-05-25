using OAuth.Provider.ApiModels;
using OAuth.Provider.DAL;
using OAuth.Provider.Filters;
using OAuth.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth.Provider.Controllers
{
    public class UserInfoController : Controller
    {
        private OAuthDbContext db;
        public UserInfoController()
        {
            db = new OAuthDbContext();
        }
        [AccessTokenValidate]
        public JsonResult BasicInfo(CommonRequest req)
        {
            var website = db.Websites.SingleOrDefault(w => w.Code == req.ClientId);
            var token = db.Tokens.SingleOrDefault(t => t.OpenId == req.OpenId && t.WebsiteId == website.Id && t.AccessToken == req.AccessToken);
            var user = db.Users.Find(token.UserId);
            BasicUserInfo binfo = new BasicUserInfo
            {
                Name = user.Name,
                Pic = string.Empty,
                Introduce = string.Empty
            };
            var data = new ApiModel<BasicUserInfo> { Success = true, Content = binfo };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [AccessTokenValidate(true)]
        public JsonResult Resource(CommonRequest req)
        {
            var website = db.Websites.SingleOrDefault(w => w.Code == req.ClientId);
            var token = db.Tokens.SingleOrDefault(t => t.OpenId == req.OpenId && t.WebsiteId == website.Id && t.AccessToken == req.AccessToken);
            var user = db.Users.Find(token.UserId);
            return Json(new ApiModel<string> { Success = true, Content = user.Resoure }, JsonRequestBehavior.AllowGet);
        }
    }
}
