using DotNetWebsite.Data;
using Microsoft.EntityFrameworkCore;

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

            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseSession();

            app.MapRazorPages();

            app.Run();

        }

    }
}
