using OAuth.Provider.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth.Provider.Controllers
{
    public class ResourcesController : Controller
    {
        //
        // GET: /Resoures/
        [OAuthAuthorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
