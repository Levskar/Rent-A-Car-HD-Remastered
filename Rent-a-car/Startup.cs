using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rent_a_car.Data;
using Rent_a_car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rent_a_car
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                

            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //    var roles = new[] { "Admin", "User" };
            //    foreach (var role in roles)
            //    {
            //        if (!await roleManager.RoleExistsAsync(role))
            //        {
            //            await roleManager.CreateAsync(new IdentityRole(role));
            //        }
            //    }

            //    string adminemailadress = "admin@rentacarhd.com";
            //    string adminpassword = "AdminskaParola1.";
            //    if (await userManager.FindByEmailAsync(adminemailadress) == null)
            //    {
            //        User admin = new User();
            //        admin.Email = adminemailadress;
            //        admin.UID = "0000000000";
            //        admin.UserName = adminemailadress;
            //        admin.EmailConfirmed = true;
            //        await userManager.CreateAsync(admin, adminpassword);
            //        await userManager.AddToRoleAsync(admin, "Admin");
            //    }
            //}

            
        }
    }
}
