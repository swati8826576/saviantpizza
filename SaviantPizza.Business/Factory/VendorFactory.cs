using SaviantPizza.Business.Enums;
using SaviantPizza.Business.IService;
using SaviantPizza.Business.Service;
using System;
using VendorAPIs.Service;

namespace SaviantPizza.Business.Factory
{
  public  class VendorFactory : VendorFactoryBase
    {

        protected override IVendor MakeVendor(int VendorId )
        {
            switch (VendorId)
            {
                case (int)Vendor.Dominos:
                        return new Dominos();

                case (int)Vendor.PizzaHut:
                    return new PizzaHut();
                default:
                    throw new ApplicationException(string.Format("This type of vendor can not be created"));
            }
        }

       
    }
}
