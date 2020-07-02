using SaviantPizza.Business.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendorAPIs.Service
{
   public abstract class VendorFactoryBase
    {
        protected abstract IVendor MakeVendor(int VendorId);
        public IVendor CreateVendor(int VendorId)
        {
            return this.MakeVendor( VendorId);
        }
    }
}
