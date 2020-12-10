using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using Activity1Part3.Services.Utility;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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
        [CustomAction]
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
                        Session["user"] = model;
                        return View("LoginPassed", model);
                    }
                    else
                    {
                        logger.Info("Parameters are: " + new JavaScriptSerializer().Serialize(model));
                        logger.Info("Exit LoginController.DoLogin() with login failing");
                        Session.Clear();
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

        //showing the customefilter
        [CustomAuthorization]
        public ActionResult onPrivateURL()
        {
            return Content("Only users logged into should be able to see this message.");
        }

        //using memory data cache
        public ActionResult GetUsers()
        {
            var cache = MemoryCache.Default;
            List<UserModel> users = new List<UserModel>();
            users = (List<UserModel>) cache.Get("users");
            if(users==null)
            {
                logger.Info("Cache was empty so we make a new list");
                users = new List<UserModel>();
                users.Add(new UserModel("Null", "Null"));

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(1);
                cache.Set("users", users, policy);
            }
            else { logger.Info("Cache isn't empty. What joy. Much fast memory retrieval."); }
            return Content(new JavaScriptSerializer().Serialize(users));
        }

    }
}