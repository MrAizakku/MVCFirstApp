using Activity1Part3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService1Controller : Controller
    {
        private readonly ILogger Logger;

        public TestLoggingService1Controller(ILogger logger)
        {
            this.Logger = logger;
        }

        // GET: TestLoggingService1
        public string Index()
        {
            Logger.Info("Test TestLoggingService1Controller Index() logger");
            return "Tested Logger";
        }
    }
}