using Activity1Part3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity1Part3.Services.Business
{
    public interface ITestService
    {
        void Initialize(ILogger logger);
        void TestLogger();
    }
}