using Activity1Part3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class CustomActionAttribute : FilterAttribute, IActionFilter
    {
        private static readonly MyLogger logger = MyLogger.GetInstance();
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            logger.Info($"We are using the CustomActionAttribute for {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName} for method {filterContext.ActionDescriptor.ActionName} and within OnActionExecuted.");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            logger.Info($"We are using the CustomActionAttribute for {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName} for method {filterContext.ActionDescriptor.ActionName} and within OnActionExecuting.");
        }
    }
}