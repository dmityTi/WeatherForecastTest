using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.BusinessEntities;
using Microsoft.AspNetCore.SignalR;
using WebApplication2.Models;

namespace WebApplication2.Services.Hubs
{
    public class WeatherHub : Hub
    {
        public async Task TestSend(ForecastRequestData data)
        {
            var paramsData = Mapper.Map<WeatherParamsData>(data);
            var id = Context.ConnectionId;

            throw new NotImplementedException();
//            await Clients.Caller.SendAsync("updateWeather", data);
        }
    }

    public class Weather : HostedService
    {
        public Weather(IHubContext<WeatherHub> context)
        {
            Clients = context.Clients;
        }

        private IHubClients Clients { get; }

        public async Task UpdateWeatherForecasts()
        {

            throw new NotImplementedException();
//            await Clients.All.SendAsync("updateWeather", WeatherForescast);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                await UpdateWeatherForecasts();

                var task = Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                try
                {
                    await task;
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }
    }
}
