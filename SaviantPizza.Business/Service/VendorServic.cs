using SaviantPizza.Business.IService;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace SaviantPizza.Business.Service
{
  
    public class VendorService : IVendorService
    {

        private readonly IVendorRepository _vendorRepository;
        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public List<VendorType> GetAllVendors()
        {
          return  _vendorRepository.Search(e=>e.IsActive == true).ToList();
        }
    }
}
