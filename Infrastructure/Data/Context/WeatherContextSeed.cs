using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure.Data.Context
{
    public static class WeatherContextSeed
    {
        public static async Task SeedAsync(WeatherContext context, IHostingEnvironment env)
        {
            context.Database.Migrate();

            if (!context.IsInitializedByDefault)
            {
                var source =
                    System.IO.File.ReadAllTextAsync(System.IO.Path.Combine(env.ContentRootPath, "cities.json")).Result;
                
                var cities =  JsonConvert.DeserializeObject<List<CityEntity>>(source);
                await context.AddRangeAsync(cities);
            }

            await context.SaveChangesAsync();
        }
    }
}