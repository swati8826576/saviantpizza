using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using SaviantPizza.Business.Factory;
using SaviantPizza.Business.Helper;
using SaviantPizza.Business.IService;
using SaviantPizza.Business.Service;
using SaviantPizza.Repository.Entity;
using SaviantPizza.Repository.IRepository;
using SaviantPizza.Repository.Repository;

namespace SaviantPizza.Web
{
    public static class StartUpExtenion
    {
        public static IServiceCollection addServices(this IServiceCollection services)
        {
            services.AddDbContext<SaviantPizzaContext>(options => options.UseSqlServer("Server=LAPTOP-4E17F3GN;Database=SaviantPizza;Integrated Security=True;"));

            // services.AddDbContext<SaviantPizzaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SaviantPizzaDBConnection")));
            services.AddScoped<IPizzaService, PizzaService>();

            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IPizzaDetailViewRepository, PizzaDetailsViewRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IDisountRepository, DiscountRepository>();
            services.AddScoped<ILoggingHelper, LoggingHelper>();

            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IDisountRepository, DiscountRepository>();

            //services.AddScoped<iven, VendorFactory>();


            services.AddScoped<VendorFactoryBase, VendorFactory>();



            return services;

        }
    }
}
