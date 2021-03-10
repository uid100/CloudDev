using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using OfficeWires.Data;

namespace OfficeWires
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Config = config;
        }
        public IConfiguration Config { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebAppDbContext>(
                    opt => opt.UseSqlite(Config.GetConnectionString("DefaultConnection"))
            );
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            SeedData.DbInit(app);
        }
    }
}
