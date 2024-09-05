using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP_Web_Application_MVC.Filter
{
    public class CustomFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData,filterContext.Controller);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData,filterContext.Controller);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData,filterContext.Controller);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData,filterContext.Controller);
        }
        private void Log(string v, RouteData routeData,ControllerBase controller)
        {
            var controllerName = routeData.Values["controller"];
            var methodName = routeData.Values["action"];
            var message = string.Format("{0}- Controller : {1} action : {2}", methodName, controllerName, v);
            
            if(controller is Controller mvccontroller){
                if(mvccontroller.ViewBag.LogMessage == null)
                {
                    mvccontroller.ViewBag.LogMessage = new List<String>();
                }
                ((List<string>)mvccontroller.ViewBag.LogMessage).Add(message);
            }

            Debug.WriteLine(message);
        }
    }
}