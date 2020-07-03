using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Web;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SaviantPizza.IntegrationTest
{
    [TestClass]
    public class PizzaControllerIntegrationTest 
    {
        private HttpClient _client;
        private TestServer _server;


        [TestInitialize]
        public void TestInitialize()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
      

        [TestMethod]
        public async Task GetPizzaDetails_ReturnsPizzaDetailsViewEntity_Test()
        {
            var response = await _client.GetAsync("/Pizza");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var PizzaDetail = JsonConvert.DeserializeObject<List<PizzaDetailsView>>(result);

            Assert.IsNotNull(PizzaDetail);
        }
    }
}
