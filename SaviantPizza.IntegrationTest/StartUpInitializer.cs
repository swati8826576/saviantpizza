using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaviantPizza.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SaviantPizza.IntegrationTest
{
    [TestClass]
    public class StartUpInitializer
    {
        public static HttpClient TestHttpClient;

        [AssemblyInitialize]
        public static void InitializeTestServer(TestContext testContext)
        {
            var testServer = new TestServer(new WebHostBuilder()
               .UseStartup<Startup>());
               // this would cause it to use StartupIntegrationTest class
               // or ConfigureServicesIntegrationTest / ConfigureIntegrationTest
               // methods (if existing)
               // rather than Startup, ConfigureServices and Configure

            TestHttpClient = testServer.CreateClient();
        }
    }
}
