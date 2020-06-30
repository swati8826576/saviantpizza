using SaviantPizza.Repository.Entity;
using SaviantPizza.Web.Models;
using System;
using System.Collections.Generic;

namespace SaviantPizza.Web.Extension
{
    public static class VendorTypeExtension
    {

        public static List<VendorViewModel> EntityToViewModel(this List<VendorType> vendors)
        {
            List<VendorViewModel> list = new List<VendorViewModel>();
            foreach (var item in vendors)
            {
                VendorViewModel viewModel = new VendorViewModel();
                viewModel.Id =  item.Id;
                viewModel.VendorName = item.VendorName;
                list.Add(viewModel);
            }
            return list;
        }
    }
}
