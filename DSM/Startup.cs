using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSM.BLL.PEPOLE;
using DSM.DAL;
using DSM.DTO;
using DSM.TABLES.Pepole;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DSM
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
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
           services.AddScoped<UserBLL>();
            services.AddScoped<BranchBLL>();
            services.AddAutoMapper(typeof(UserProfile));
            

            services.AddDbContext<DSMDBContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("con"));
            });
                
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "area", pattern: "{area:exists}/{controller=User}/{action=Index}/{id?}");

            });
        }
    }
}
