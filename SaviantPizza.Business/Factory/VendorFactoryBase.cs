using SaviantPizza.Business.Enums;
using SaviantPizza.Business.IService;

namespace SaviantPizza.Business.Factory
{
   public abstract class VendorFactoryBase
    {
        protected abstract IVendor MakeVendor(int VendorId);
        public IVendor CreateVendor(int VendorId)
        {
            return this.MakeVendor( VendorId );
        }
    }
}
