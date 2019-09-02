using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication2.Filters
{
    public class GlobalExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            Console.WriteLine($"  Message: {context?.Exception?.Message}," + Environment.NewLine +
                              $" Sourse: {context?.Exception?.Source}, " + Environment.NewLine +
                              $"TargetSite: {context?.Exception?.TargetSite}" + Environment.NewLine +
                              $"StackTrace: {context?.Exception?.StackTrace}" + Environment.NewLine +
                              $"");

            //save to log file
            return Task.CompletedTask;
        }
    }
}
