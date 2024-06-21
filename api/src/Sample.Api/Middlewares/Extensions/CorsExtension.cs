using Microsoft.AspNetCore.Builder;
using Sample.Common.Constants;

namespace Sample.Api.Middlewares.Extensions
{
    /// <summary>
    /// cors middleware extension
    /// </summary>
    public static class CorsExtension
    {
        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app) =>
            app.UseCors(CorsPolicy.Name);
    }
}