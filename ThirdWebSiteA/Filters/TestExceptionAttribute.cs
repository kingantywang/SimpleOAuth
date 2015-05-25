using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThirdWebSiteA.Filters
{
    public class TestExceptionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("~/api/Test/GetTwo");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("~/api/Test/GetTwo");
        }

    }

    public class CustomException : Exception
    {
        public CustomException()
            : base()
        { }
        public CustomException(string msg) :
            base(msg)
        { }
    }

    //public class CustomExceptionAttribute : FilterAttribute, IExceptionFilter
    //{

    //    public void OnException(ExceptionContext filterContext)
    //    {
    //        if (filterContext.ExceptionHandled == true)
    //        {
    //            HttpException httpExce = filterContext.Exception as HttpException;
    //            if (httpExce.GetHttpCode() != 500)//为什么要特别强调500 因为MVC处理HttpException的时候，如果为500 则会自动
    //            //将其ExceptionHandled设置为true，那么我们就无法捕获异常
    //            {
    //                return;
    //            }
    //        }
    //        if (filterContext.Exception.GetType().Name == "CustomException")
    //        {
    //            filterContext.HttpContext.Response.Redirect("~/Home/Index");
    //        }
    //    }
    //}
}