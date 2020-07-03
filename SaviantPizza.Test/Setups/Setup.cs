using SaviantPizza.Repository.Entity;
using System;
using System.Collections.Generic;

namespace SaviantPizza.Test.Setup
{
    public static class Setup
    {
        public static List<PizzaDetailsView> GetPizzaDetails()
        {
            List<PizzaDetailsView> pizzaList = new List<PizzaDetailsView>();
            PizzaDetailsView obj = new PizzaDetailsView()
            {
                PizzaCategoryId = 1,
                PizzaCategoryName = "",
                CategoryIsActive = true,
                PizzaTypeId = 1,
                PizzaName = "",
                PizzaTypeIsActive = true,
                CategoryId = 1,
                PricingId = 1,
                PizzaId = 1,
                VendorId = 1,
                Price = 100,
                Discount = 10,
                VendorTypeId = 1,
                VendorName = "",
                VendorTypeIsActive = true
            };
            pizzaList.Add(obj);
            return pizzaList;
        }


        public static List<Order> GetOrderEntities()
        {
            List<Order> orderList = new List<Order>();
            Guid orderID = new Guid();
            Order order = new Order()
            {
                Id = orderID,
                UserId = new Guid(),
                OrdeTotal = 100,
                OrderDetails = Setup.GetOrderDetailsEntity(orderID)
            };
            orderList.Add(order);
            return orderList;

        }

        private static List< OrderDetails> GetOrderDetailsEntity(Guid id)

        {
            List<OrderDetails> orderDetailsList = new List<OrderDetails>();
            OrderDetails orderDetails = new OrderDetails() {
                Id = new Guid(),
                PizzaTypeId = 1,
                VendorId = 1,
                Price = 120,
                Discount = 10,
                OtherDiscount = 10,
                TotalAfterDiscount = 100,
                OrderId = id
            };
            orderDetailsList.Add(orderDetails);
            return orderDetailsList;
        }


    }
}
