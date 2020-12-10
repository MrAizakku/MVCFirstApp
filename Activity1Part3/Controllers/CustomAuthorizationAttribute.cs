using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using System;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    internal class CustomAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            SecurityService securityService = new SecurityService();
            UserModel user = (UserModel) filterContext.HttpContext.Session["user"];
            bool success = securityService.Authenticate(user);
            if (!success)
            {
                filterContext.Result = new RedirectResult("/login");
            }
        }
    }
}