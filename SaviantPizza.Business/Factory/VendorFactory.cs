using SaviantPizza.Business.Enums;
using SaviantPizza.Business.IService;
using SaviantPizza.Business.Service;
using System;
using System.Collections.Generic;
using System.Text;
using VendorAPIs.Service;

namespace SaviantPizza.Business.Factory
{
  public  class VendorFactory : VendorFactoryBase
    {

        protected override IVendor MakeVendor(int VendorId)
        {
            switch (VendorId)
            {
                case (int)Vendor.Dominos:
                    return new Dominos();

                case (int)Vendor.PapaJohn:
                    return new PapaJohns();
                default:
                    throw new ApplicationException(string.Format("This type of vendor can not be created"));
            }
        }
    }
}
