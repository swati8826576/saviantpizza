using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.Repository;
using SaviantPizza.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SaviantPizza.Web.Extension
{
    public static  class OrderExtension
    {
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
                    orderDetail.OtherDiscount = 0;
                    orderDetail.PizzaTypeId = pizzaDetail.PizzaId;
                    orderDetail.Price = pizzaDetail.Price;
                    orderDetail.TotalAfterDiscount = pizzaDetail.DiscountedPrice;
                    orderDetail.VendorId = item.VendorId;
                    order.OrdeTotal = order.OrdeTotal + orderDetail.TotalAfterDiscount;
                    order.OrderDetails.Add(orderDetail);

                }

                if (order.OrderDetails.Count() > 0)
                orderList.Add(order);



            }
            return orderList;
        }

        private static decimal CalculateDiscountedPrice(decimal? discount, decimal? price)
        {
            var percentage = (discount * 100) / price;
            var total = price - percentage;
            return total.HasValue ? Math.Floor(total.Value) : 0;
        }

    }
}
