
using SaviantPizza.Business.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendorAPIs.Service
{
    public class PapaJohns : IVendor
    {
        public bool placeOrder()
        {
            return true;
        }
    }
}
