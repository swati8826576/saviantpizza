using SaviantPizza.Repository.Entity;
using System.Collections.Generic;

namespace SaviantPizza.Business.IService
{
    public interface IOrderService
    {
        Order SaveOrder(List<Order> orders);
    }
}
