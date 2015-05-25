using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OAuth.Provider.Helper
{
    public class OAuthAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userCookie = httpContext.Request.Cookies["AccountInfo"];
            if (userCookie != null)
                return true;
            else
                return false;
            //var auth = httpContext.User.Identity as FormsIdentity;
            //if (auth == null || !auth.IsAuthenticated) 
            //    return false;
            //return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        Message = "Ajax_UnAuthorized"
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            string queryString=filterContext.HttpContext.Request.Url.PathAndQuery;
            if (string.IsNullOrEmpty(queryString))
            {
                queryString = @"~/Home/Index";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(queryString);
            string returnUrl = Convert.ToBase64String(bytes);
            filterContext.Result = new RedirectResult("~/Account/Login?returnUrl=" + returnUrl);
        }
    }
}