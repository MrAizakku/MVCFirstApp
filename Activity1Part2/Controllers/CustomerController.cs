using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public string GetAllCustomers()
        {
            return @"<ul>
                    <li>Ali Raza</li>
                    <li>Mark Upston</li>
                    <li>Allan Bommer</li>
                    <li>Greg Jerry</li>
                    </ul>";
        }
    }
}