using SaviantPizza.Repository.Entity;

namespace SaviantPizza.Business.IService
{
  public  interface ILoginService
    {
        bool Login(User user);

    }
}
