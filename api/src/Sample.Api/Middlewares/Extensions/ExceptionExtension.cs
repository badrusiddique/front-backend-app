using Microsoft.AspNetCore.Builder;
using Sample.Api.Middlewares;

namespace Sample.Api.Middlewares.Extensions
{
    /// <summary>
    /// custom exception middleware extension
    /// </summary>
    public static class ExceptionExtension
    {
        public static IApplicationBuilder UseCustomException(this IApplicationBuilder app) =>
            app.UseMiddleware<CustomExceptionMiddleware>();
    }
}