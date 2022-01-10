using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1._Calculator
{
    public class Calculate
    {
        private readonly RequestDelegate _next;
        public Calculate(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string p1 = context.Request.Query["p1"];
            string p2 = context.Request.Query["p2"];
            string prop = context.Request.Query["prop"];

            if (p1 == null || p2 == null || prop == null)
            {
                await context.Response.WriteAsync("Not full params!");
            }
            else
            {
                if (prop == "add")
                {
                    await context.Response.WriteAsync($"<h1>{double.Parse(p1) + double.Parse(p2)}</h1>");
                }
                else if (prop == "minus")
                {
                    await context.Response.WriteAsync($"<h1>{double.Parse(p1) - double.Parse(p2)}</h1>");
                }
                else if (prop == "mult")
                {
                    await context.Response.WriteAsync($"<h1>{double.Parse(p1) * double.Parse(p2)}</h1>");
                }
                else if (prop == "divis")
                {
                    await context.Response.WriteAsync($"<h1>{double.Parse(p1) / double.Parse(p2)}</h1>");
                }

                await _next.Invoke(context);
            }
        }
    }
}
