using SaviantPizza.Repository.Entity;
using SaviantPizza.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaviantPizza.Web.Extension
{
    /// <summary>
    /// this class is an extension to PizzaDetailView Type
    /// </summary>
    public static class PizzaDetailsExtension
    {

        /// <summary>
        /// Converts entity to viewmodel
        /// </summary>
        /// <param name="pizzaDetailsViewList"></param>
        /// <returns>list of view model</returns>
        public static List<PizzaDetailsViewModel> EntityToViewModel( this List<PizzaDetailsView> pizzaDetailsViewList)
        {
            List<PizzaDetailsViewModel> viewModelList = new List<PizzaDetailsViewModel>();
            foreach (var item in pizzaDetailsViewList)
            {
                if (!viewModelList.Any(e => e.VendorId == item.VendorTypeId))
                {
                    PizzaDetailsViewModel viewModel = new PizzaDetailsViewModel();
                    viewModel.VendorId = item.VendorTypeId;
                    viewModel.VendorName = item.VendorName;
                    viewModel.IsSelected = false;
                    viewModel.isClosed = false;

                    var PizzaCountByVendor = pizzaDetailsViewList.Where(e => e.VendorId == item.VendorTypeId);
                    List<PizzaDetails> lst = new List<PizzaDetails>();

                    foreach (var details in PizzaCountByVendor)
                    {
                        PizzaDetails detail = new PizzaDetails();
                        detail.PizzaId = details.PizzaId;
                        detail.PizzaName = details.PizzaName;
                        detail.Price = details.Price;
                        detail.DiscountedPrice = CalculateDiscountedPrice(details.Discount, details.Price);
                        lst.Add(detail);

                    }

                    viewModel.pizzaDetails = lst;
                    viewModelList.Add(viewModel);
                }
            }
            return viewModelList;
        }

        /// <summary>
        /// calculates discounted price using actual price and given discount
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="price"></param>
        /// <returns>final price</returns>
        private static decimal CalculateDiscountedPrice(decimal? discount, int? price)
        {
            var percentage =( discount * price) / 100 ;
            var total =price - percentage;
            return total.HasValue? Math.Floor(total.Value) : 0;
        }
    }
}
