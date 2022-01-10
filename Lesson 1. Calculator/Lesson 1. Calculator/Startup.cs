using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1._Calculator
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<RToken>();
            app.UseMiddleware<Calculate>();

            app.Use(async (context, next) =>
            {
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("qwe");
            });
        }
    }
}
