using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;

namespace SaviantPizza.Repository.Repository
{

    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {

        public OrderRepository(SaviantPizzaContext dbContext)
         : base(dbContext)
        {

        }

      
    }
}
