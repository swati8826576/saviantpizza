using SaviantPizza.Repository.Entity;
using SaviantPizza.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaviantPizza.IntegrationTest
{
    public static class SetUp
    {
        public static List<PizzaDetailsViewModel> GetPizzaDetails()
        {
            List<PizzaDetailsViewModel> pizzaList = new List<PizzaDetailsViewModel>();
            PizzaDetailsViewModel obj = new PizzaDetailsViewModel()
            {
                VendorId = 1,
                VendorName = "Dominos",
                IsSelected = true,
                isClosed = false,
                OtherDiscount = 10,
                pizzaDetails = SetUp.GetDetails()
        };
        pizzaList.Add(obj);
            return pizzaList;
        }




    private static List<PizzaDetails> GetDetails()

    {
        List<PizzaDetails> orderDetailsList = new List<PizzaDetails>();
        PizzaDetails orderDetails = new PizzaDetails()
        {
            PizzaId = 1,
            PizzaName = "Margherita",
            Price = 120,
            DiscountedPrice = 10,
            IsSelected = true,
        };
        orderDetailsList.Add(orderDetails);
        return orderDetailsList;
    }

}
}
