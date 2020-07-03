using SaviantPizza.Repository.Entity;
using SaviantPizza.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaviantPizza.Web.Extension
{
    /// <summary>
    /// This class is an extension to order type 
    /// </summary>
    public static  class OrderExtension
    {
        /// <summary>
        /// Converts viewmodel to entity
        /// </summary>
        /// <param name="viewModelList"></param>
        /// <param name="userId"></param>
        /// <returns>list of order entity</returns>
        public static List<Order> ViewModelToEntity( List<PizzaDetailsViewModel> viewModelList ,string userId )
        {

            List<Order> orderList = new List<Order>();

            foreach (var item in viewModelList)
            {
                Order order = new Order();
                order.Id = new Guid();
                 order.UserId = Guid.Parse(userId);

                order.OrdeTotal = 0;

                foreach (var pizzaDetail in item.pizzaDetails.Where(e=>e.IsSelected == true))
                {
                    OrderDetails orderDetail = new OrderDetails();
                    orderDetail.Id = new Guid();
                    orderDetail.Discount = pizzaDetail.DiscountedPrice;
                    orderDetail.OtherDiscount = item.OtherDiscount;
                    orderDetail.PizzaTypeId = pizzaDetail.PizzaId;
                    orderDetail.Price = pizzaDetail.Price;
                    orderDetail.TotalAfterDiscount = CalculatePriceAfterAllDiscounts(pizzaDetail.DiscountedPrice, item.OtherDiscount);
                    orderDetail.VendorId = item.VendorId;
                    order.OrdeTotal = order.OrdeTotal + orderDetail.TotalAfterDiscount ;
                    order.OrderDetails.Add(orderDetail);

                }

                if (order.OrderDetails.Count() > 0)
                orderList.Add(order);



            }
            return orderList;
        }


        private static decimal CalculatePriceAfterAllDiscounts(decimal DiscountedPrice, decimal? OtherDiscount)
        {
            var percentage = (OtherDiscount * DiscountedPrice) / 100;
            var total = DiscountedPrice - percentage;
            return total.HasValue ? Math.Floor(total.Value) : 0;
        }
      

    }
}
