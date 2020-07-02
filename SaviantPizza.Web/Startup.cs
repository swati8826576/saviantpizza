using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaviantPizza.Business.IService;
using SaviantPizza.Business.Service;
using SaviantPizza.Repository.IRepository;
using SaviantPizza.Repository.Repository;
using SaviantPizza.Repository.Entity;
using Microsoft.Extensions.Logging;
using SaviantPizza.Web.Controllers;

namespace SaviantPizza.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

           

            services.AddMvc();
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<SaviantPizzaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SaviantPizzaDBConnection")));
            services.AddScoped<IPizzaService, PizzaService>();

            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IPizzaDetailViewRepository, PizzaDetailsViewRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository,OrderRepository>();

            services.AddScoped<IDisountRepository, DiscountRepository>();


            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           // app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

           // loggerFactory.AddFile("Logs/myapp-{Date}.txt");
        }
    }
}
