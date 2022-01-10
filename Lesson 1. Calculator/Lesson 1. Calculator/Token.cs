using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1._Calculator
{
    public class RToken
    {
        private readonly RequestDelegate _next;
        public RToken(RequestDelegate next)
        {
            _next = next;
        }

        string[] tokens = { "qwe", "tre" };
        private bool CheckToken(string token)
        {
            foreach (string item in tokens)
            {
                if (token == item)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string token = context.Request.Query["token"];

            if (token == null || !CheckToken(token))
            {
                await context.Response.WriteAsync($"No token!");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
