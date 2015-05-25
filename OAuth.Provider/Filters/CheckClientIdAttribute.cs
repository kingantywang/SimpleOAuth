using OAuth.Provider.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth.Provider.Helper
{
    [Obsolete]
    public class CheckClientIdAttribute : ActionFilterAttribute
    {
        private OAuthDbContext db;
        public CheckClientIdAttribute()
        {
            db = new OAuthDbContext();
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string responseType = filterContext.HttpContext.Request.QueryString.Get("responseType").Trim();
            if (responseType.ToUpper() != "CODE")
            {
                filterContext.Result = new RedirectResult("~/StaticPage/ErrorCode");
            }
            string clientId = filterContext.HttpContext.Request.QueryString.Get("clientId").Trim();
            string returnUrl = filterContext.HttpContext.Request.QueryString.Get("return_Url").Trim();
            var client = db.Websites.SingleOrDefault(w => w.Code == clientId);
            if (client == null)
            {
                filterContext.Result = new RedirectResult("~/StaticPage/ErrorClient");
            }
            //if (!client.ReturnUrl.Contains(returnUrl))
            //{
            //    filterContext.Result = new RedirectResult("~/StaticPage/ErrorUrl");
            //}
        }
    }
}