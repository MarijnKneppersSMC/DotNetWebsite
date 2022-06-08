using DotNetWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DotNetWebsite
{
    class Program {

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddRazorPages()
                //TODO: just make this 2 seperate statements. Readability over less repetition in this case
#if DEBUG
                //This would only take up resources in production without any use
                .AddRazorRuntimeCompilation();
#else
                //terminate if not in release
                ;
#endif

            string connectionString = builder.Configuration.GetConnectionString("HomeConnection");
            builder.Services.AddDbContext<DatabaseContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>();

            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = "DotNetMovieDatabase.Session";
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.IsEssential = true;
            });

            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

			app.UseStatusCodePagesWithRedirects("/StatusCode/{0}");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            SetupAuthentication(app.Services);

            app.UseCookiePolicy();

            app.UseSession();

            app.MapRazorPages();

            app.Run();

        }

        private static async void SetupAuthentication(IServiceProvider serviceProvider)
        {
            string[] roles = { "Admin" };

            using (var scope = serviceProvider.CreateScope())
            {

                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                for (int i = 0; i < roles.Length; i++)
                {
                    bool roleExists = await roleManager.RoleExistsAsync(roles[i]);
                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(roles[i]));
                    }
                }
            }
        }

    }
}
