using OAuth.Provider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth.Provider.Controllers
{
    public class ApiErrorController : Controller
    {
        [HttpGet]
        public JsonResult AccessTokenError()
        {
            return Json(new ApiModel<string> { Success = false, Content = "传入参数经验证无效,无法访问此Api" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult NoScope()
        {
            return Json(new ApiModel<string> { Success = false, Content = "无权限读取此Api内容" }, JsonRequestBehavior.AllowGet);
        }
    }
}
