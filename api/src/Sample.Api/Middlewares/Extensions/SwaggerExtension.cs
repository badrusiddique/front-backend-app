using Microsoft.AspNetCore.Builder;

namespace Sample.Api.Middlewares.Extensions
{
    /// <summary>
    /// swagger middleware extension
    /// </summary>
    public static class SwaggerExtension
    {
        public static IApplicationBuilder UseSwaggerWithUI(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            return app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.DocumentTitle = "Sample Web API";
                c.SwaggerEndpoint("swagger/./v1/swagger.json", "Sample Web API V1");
                c.DisplayRequestDuration();
            });
        }
    }
}