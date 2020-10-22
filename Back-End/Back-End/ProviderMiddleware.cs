using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Back_End
{
    public class ApiMiddleware
    {
        private readonly RequestDelegate next;
        public ApiMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Expose-Headers", "*");
            await next(context);
        }
    }
    public static class ProviderMiddleware
    {
        public static IApplicationBuilder UseApiMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiMiddleware>();
        }
    }
}
