using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace Sample.Api.HealthChecks
{
    public class HealthCheckOption
    {
        public static HealthCheckOptions Create { get; } = new HealthCheckOptions { ResponseWriter = ParseResponse };

        internal static async Task ParseResponse(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            var result = JsonConvert.SerializeObject(
                new
                {
                    status = report.Status.ToString(),
                    checks = report.Entries.Select(e => ParseResponseEntry(e.Key, e.Value)),
                    totalResponseTime = $"{report.TotalDuration.TotalMilliseconds} ms"
                },
                Formatting.Indented,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            await context.Response.WriteAsync(result);
        }

        private static dynamic ParseResponseEntry(string key, HealthReportEntry value) =>
            new
            {
                status = value.Status.ToString(),
                description = key,
                responseTime = $"{value.Duration.TotalMilliseconds} ms"
            };
    }
}