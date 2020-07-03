using SaviantPizza.Business.IService;
using SaviantPizza.Repository.IRepository;
using System;
using System.Linq;

namespace SaviantPizza.Business.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IDisountRepository _discountRepository;
        public DiscountService(IDisountRepository discountRepository)
        {
            _discountRepository = discountRepository; 
        }
        public decimal? GetDiscount()
        {
            return _discountRepository.GetAll().FirstOrDefault().Discount;
        }
    }
}
