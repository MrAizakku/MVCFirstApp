﻿using Activity1Part3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService2Controller : Controller
    {
        [Dependency]
        public ILogger Logger { get; set; }

        // GET: TestLoggingService2
        public string Index()
        {
            Logger.Info("Inside TestLoggingService2Controller Index()");
            return "Test Complete";
        }
    }
}