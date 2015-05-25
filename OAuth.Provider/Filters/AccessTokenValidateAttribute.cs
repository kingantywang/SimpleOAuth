using OAuth.Provider.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth.Provider.Filters
{
    public class AccessTokenValidateAttribute : ActionFilterAttribute
    {
        private OAuthDbContext db;
        private bool Scope;
        /// <summary>
        /// 是否带权限验证
        /// </summary>
        /// <param name="scope">权限</param>
        public AccessTokenValidateAttribute(bool scope = false)
        {
            db = new OAuthDbContext();
            this.Scope = scope;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var query = filterContext.HttpContext.Request.QueryString;
            long openId = long.Parse(query.Get("OpenId").Trim());
            string accessToken = query.Get("AccessToken").Trim();
            string clientId = query.Get("ClientId").Trim();
            var website = db.Websites.SingleOrDefault(w => w.Code == clientId);
            if (website == null)
                filterContext.HttpContext.Response.Redirect("~/ApiError/AccessTokenError", true);
            var token = db.Tokens.SingleOrDefault(t => t.OpenId == openId && t.WebsiteId == website.Id && t.AccessToken == accessToken && t.Effective && DateTime.Compare(t.Expire, DateTime.Now) > 0);
            if (token == null)
                filterContext.HttpContext.Response.Redirect("~/ApiError/AccessTokenError", true);
            if (Scope && !token.Scope)
                filterContext.HttpContext.Response.Redirect("~/ApiError/NoScope", true);
        }
    }
}