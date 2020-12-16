using Activity1Part3.Services.Business;
using Activity1Part3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService3Controller : Controller
    {
        private readonly ILogger Logger;
        private readonly ITestService TestService;

        public TestLoggingService3Controller(ILogger logger, ITestService testService)
        {
            Logger = logger;
            TestService = testService;
        }

        // GET: TestLoggingService3
        public string Index()
        {
            Logger.Info("In TestLoggingService3Controller calling Info on the Logger.");
            TestService.TestLogger();
            return "Hello. I am a string.";
        }
    }
}