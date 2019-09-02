using System;
using System.Threading.Tasks;
using Infrastructure.Data.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
//            CreateWebHostBuilder(args).Build().Run();


            //Get the IWebHost which will host this application.
            var host = CreateWebHostBuilder(args).Build();

            //Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<WeatherContext>();
                    var environment = services.GetRequiredService<IHostingEnvironment>();
                    await WeatherContextSeed.SeedAsync(context, environment);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //Continue to run the application
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>();
    }
}
