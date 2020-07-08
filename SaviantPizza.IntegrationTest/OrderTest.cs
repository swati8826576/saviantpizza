using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SaviantPizza.Web;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SaviantPizza.IntegrationTest
{

    [TestClass]
    public class OrderTest
    {

        [TestMethod]
        public async Task PlaceOrder_ReturnsTrue_Test()
        {
            var orderMadeByUser = SetUp.GetPizzaDetails();

            var json = JsonConvert.SerializeObject(orderMadeByUser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await StartUpInitializer.TestHttpClient.PostAsync("/Order", data);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            var isOrderPaced = JsonConvert.DeserializeObject<bool>(result);

            Assert.IsTrue(isOrderPaced);
        }
        }
}
