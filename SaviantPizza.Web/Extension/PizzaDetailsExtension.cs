using SaviantPizza.Repository.Entity;
using SaviantPizza.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaviantPizza.Web.Extension
{
    public static class PizzaDetailsExtension
    {

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


        private static decimal CalculateDiscountedPrice(decimal? discount, int? price)
        {
            var percentage =( discount * 100) / price ;
            var total =price - percentage;
            return total.HasValue? Math.Floor(total.Value) : 0;
        }
    }
}
