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
      

        [TestMethod]
        public async Task GetPizzaDetails_ReturnsPizzaDetailsViewEntity_Test()
        {
            var response = await StartUpInitializer.TestHttpClient.GetAsync("/Pizza");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var PizzaDetail = JsonConvert.DeserializeObject<List<PizzaDetailsView>>(result);

            Assert.IsNotNull(PizzaDetail);
        }
    }
}
