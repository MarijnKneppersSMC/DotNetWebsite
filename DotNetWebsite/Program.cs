using DotNetWebsite.Models;

namespace DotNetWebsite
{
    class Program {

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            Console.WriteLine(builder.Configuration.GetConnectionString("SchoolConnection"));

            //connection string moet HomeConnection of SchoolConnection zijn.
            builder.Services.Add(new ServiceDescriptor(typeof(MovieContext), new MovieContext(builder.Configuration.GetConnectionString("SchoolConnection"))));

            WebApplication app = builder.Build();

            //Currently using ! to override nullable. Need to add an actual check
            app.Lifetime.ApplicationStopping.Register(() => { ((MovieContext)app.Services.GetService(typeof(MovieContext))!).CloseConnection(); });

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