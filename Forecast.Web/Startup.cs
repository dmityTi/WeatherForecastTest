using System;
using Domain.Interfaces.Data;
using Domain.Interfaces.Integration.Provider;
using Domain.Interfaces.Service;
using Domain.Providers;
using Domain.Providers.Interfaces;
using Domain.Services;
using Infrastructure;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Integrations.Clients;
using Infrastructure.Integrations.Clients.Interfaces;
using Infrastructure.Integrations.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using WebApplication2.Providers;
using WebApplication2.Services.Hubs;

//using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebApplication2
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
            services.AddMvc();
            services.AddSignalR();

            services.AddScoped<WeatherForecastProvider>();
            services.AddScoped<IWeatherProvider, DarkSkyProvider>();
            services.AddScoped<IWeatherProvider, OpenWeatherMapProvider>();
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<ICommonWeatherProvider, CommonWeatherProvider>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
//            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<,>));
//            services.AddTransient<ICityRepository, CityRepository>();


            services.AddHttpClient<IOpenWeatherClient, OpenWeatherClient>(client =>
                {
                    client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
                })
                .AddTransientHttpErrorPolicy(p =>
                    p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
//.SetHandlerLifetime(TimeSpan.FromMinutes(10));

            services.AddHttpClient<IDarkSkyClient, DarkSkyClient>(client =>
                {
                    client.BaseAddress = new Uri("https://api.darksky.net/");
                })
                .AddTransientHttpErrorPolicy(p =>
                    p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
            //определена политика WaitAndRetryAsync. Неудачные запросы повторяются до трех раз с задержкой 600 мс между попытками.


            var connectionString = Configuration.GetConnectionString("ForecastDBConnection");
            services.AddDbContext<WeatherContext>(options =>
            {
//                options.UseInMemoryDatabase("TestOrderDB");
                options.UseSqlServer(connectionString);
//                options.EnableSensitiveDataLogging();
            });


            Mapping.MappingConfig.RegisterMapping();
            DIConfigure.Configure(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Webpack initialization with hot-reload.
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<WeatherHub>("/weather");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
