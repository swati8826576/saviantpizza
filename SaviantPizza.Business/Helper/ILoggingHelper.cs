using SaviantPizza.Repository.Entity;

namespace SaviantPizza.Business.Helper
{
   public  interface ILoggingHelper
    {
        void LogOrderInformation(Order order);
    }
}
