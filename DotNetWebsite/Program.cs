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

            string connectionString = builder.Configuration.GetConnectionString("SchoolConnection");
            builder.Services.AddDbContext<DatabaseContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();

        }

    }
}
