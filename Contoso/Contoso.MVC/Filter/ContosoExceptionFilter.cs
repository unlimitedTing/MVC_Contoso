using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace Contoso.MVC.Filter
{
    public class ContosoExceptionFilter: HandleErrorAttribute
    {
        public ContosoExceptionFilter()
        {

        }

        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string) filterContext.RouteData.Values["controller"];//give you controller name
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName); // show the info on the error view
            filterContext.Result = new ViewResult {
                ViewName = View,
                MasterName =Master,
                ViewData =new ViewDataDictionary<HandleErrorInfo>(model),
                TempData=filterContext.Controller.TempData
            };// give the property value of handleErrorAttribute

            // put url
            string exceptionPath = filterContext.HttpContext.Request.Path + filterContext.HttpContext.Request.QueryString;

            // log exception information like
            // 1.Exception: filterContext.Exception
            // 2.Inner message
            // 3.DateTime: datetime.now
            // 4.Action method & controller name
            // 5.The whole stack traces : from exception
            // 6.Exception Path (URL)
            // 7.Log above details using NLog to text files

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500; // 500 => exception happen

            Logger logger = LogManager.GetCurrentClassLogger();

            logger.Info(filterContext.Exception, "whoops");

            base.OnException(filterContext);
        }
    }
}