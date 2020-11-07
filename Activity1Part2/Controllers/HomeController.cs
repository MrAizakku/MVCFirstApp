using Activity1Part2.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part2.Controllers
{
    [MyLogActionFilter]
    public class HomeController : Controller
    {
        /*
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("GetAllCustomers", "Customer");
        }
        */
        // GET: Home
        [OutputCache(Duration = 10)]
        public string Index()
        {
            return "This is ASP.Net MVC Filters Tutorial";
        }

        [OutputCache(Duration = 10)]
        [ActionName("CurrentTime")]
        public string GetCurrentTime()
        {
            return TimeString();
        }

        [NonAction]
        public string TimeString()
        {
            return "Time is " + DateTime.Now.ToString("T");
        }

        public string Mycontroller()
        {
            return "Hi, I am a controller";
        }

        public ActionResult MyView()
        {
            return View();
        }
    }
}