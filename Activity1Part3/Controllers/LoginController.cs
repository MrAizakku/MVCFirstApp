using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using Activity1Part3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
        private static MyLogger logger = MyLogger.GetInstance();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            logger.Info("Entering LoginController.Login()");

            try
            {
                if (ModelState.IsValid)
                {

                    SecurityService sservice = new SecurityService();
                    bool results = sservice.Authenticate(model);
                    if (results)
                    {
                        logger.Info("Parameters are: " + new JavaScriptSerializer().Serialize(model));
                        logger.Info("Exit LoginControlle.DoLogin() with login passing");
                        return View("LoginPassed", model);
                    }
                    else
                    {
                        logger.Info("Parameters are: " + new JavaScriptSerializer().Serialize(model));
                        logger.Info("Exit LoginController.DoLogin() with login failing");
                        return View("LoginFailed");
                    }
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception e)
            {
                logger.Error("Exception LoginController.DoLogin()" + e.Message);
                return Content("Exception in login" + e.Message);
            }
        }

    }
}