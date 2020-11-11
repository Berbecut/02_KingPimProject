using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPimV1.DB;
using KingPimV1.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KingPimV1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            var conn = Configuration.GetConnectionString("KingPimContextConnection");

            services.AddDbContext<KingPimDatabaseContext>(options => options.UseSqlServer(conn));

            services.AddIdentity<IdentityUser, IdentityRole>().
                AddEntityFrameworkStores<KingPimDatabaseContext>().
                AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            });

            services.AddTransient<IIdentitySeeder, IdentitySeeder>();
            services.AddTransient<IDataRepository, DataRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IIdentitySeeder identitySeeder, KingPimDatabaseContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages(); // felhantering implementation
            }
            else
            {
                app.UseExceptionHandler("/error.html");
                app.UseStatusCodePagesWithReExecute("/Error/Error", "?statusCode={0}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });

            identitySeeder.CreateAdminAccountIFEmpty();
        }
    }
}
