using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth.Provider.Helper
{
    public class HttpsRequireAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //if (!filterContext.HttpContext.Request.IsSecureConnection)
            //{
            //    string path = filterContext.HttpContext.Request.Path;
            //    string host = filterContext.HttpContext.Request.RawUrl;
            //}
            //filterContext.HttpContext.Response.Redirect("https://localhost:/Home/Index");
        }
    }
}