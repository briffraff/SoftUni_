namespace Panda.App
{
    using System.Linq;
    using Panda.Models;
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

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
            services.AddDbContext<PandaDBExtended>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<PandaUser, PandaUserRole>()
                .AddEntityFrameworkStores<PandaDBExtended>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                options.SignIn.RequireConfirmedEmail = false;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<PandaDBExtended>())
                {
                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    if (context.Roles.Any() == false)
                    {
                        context.Add(new PandaUserRole { Name = "Admin", NormalizedName = "ADMIN" });
                        context.Add(new PandaUserRole { Name = "User", NormalizedName = "USER" });
                    }

                    if (context.PackageStatuses.Any() == false)
                    {
                        context.PackageStatuses.Add(new PackageStatus {Name = "Pending"}); ;
                        context.PackageStatuses.Add(new PackageStatus {Name = "Shipped"}); ;
                        context.PackageStatuses.Add(new PackageStatus {Name = "Delivered"}); ;
                        context.PackageStatuses.Add(new PackageStatus {Name = "Acquired"}); ;
                    }

                    context.SaveChanges();
                }
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
