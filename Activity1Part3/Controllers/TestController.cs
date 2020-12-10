using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [HttpGet]
        [CustomAuthorization]
        public ActionResult Index()
        {
            return Content("This is the index of the Test controller. Are you allowed to be here?");
        }
    }
}