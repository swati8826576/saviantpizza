//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SaviantPizza.IntegrationTest
{
   // [TestClass]
    public class PizzaControllerIntegrationTest :   IClassFixture<TestingWebAppFactory<Startup>>
    {
         private readonly HttpClient _client;
        //private TestServer _server;


        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    _server = new TestServer(new WebHostBuilder()
        //        .UseStartup<Startup>());
        //    _client = _server.CreateClient();
        //}

        public PizzaControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }


        //[Fact]
        //public async Task Index_WhenCalled_ReturnsApplicationForm()
        //{
        //    var response = await _client.GetAsync("/Pizza");

        //    response.EnsureSuccessStatusCode();

        //    var responseString = response.Content.ReadAsAsync<Post>();


        //}

        [Fact]
        public async Task GetPerson()
        {
            var response = await _client.GetAsync("/Pizza");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var person = JsonConvert.DeserializeObject<PizzaDetailsView>(result);

            Assert.AreEqual("Margherita", person.PizzaName);
        }
    }

}
