using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sample.Api.Responses;
using Sample.Common.Enums;
using Sample.Common.Exceptions;
using Sample.Common.Extensions;
using HttpContextCore = Microsoft.AspNetCore.Http.HttpContext;

namespace Sample.Api.Middlewares
{
    /// <summary>
    /// custom error exception middleware
    /// </summary>
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContextCore httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContextCore httpContext, Exception ex)
        {
            ErrorResponse error;
            HttpStatusCode statusCode;

            switch (ex)
            {
                case ArgumentException argEx:
                    error = ParseErrorResponse(argEx, ErrorCodes.InvalidArg);
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case AuthenticationExceptionBase authEx:
                    error = ParseErrorResponse(authEx, ErrorCodes.Unauthorized);
                    statusCode = HttpStatusCode.Unauthorized;
                    break;

                case ValidationException valEx:
                    error = ParseErrorResponse(valEx, ErrorCodes.InvalidRequestArg);
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                default:
                    var defaultEx = new Exception($"the server encountered an internal error or misconfiguration and was unable to complete your request: {ex.Message}", ex);
                    error = ParseErrorResponse(defaultEx);
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError($"API-Request failed: {error}", JsonCovertExtension.SerializeObject(ex));
            await WriteResponseAsync(httpContext, ResponseBase.ParseResponse(statusCode, error));
        }

        private async Task WriteResponseAsync(HttpContextCore httpContext, ResponseBase response)
        {
            httpContext.Response.StatusCode = (int)response.StatusCode;
            httpContext.Response.ContentType = "application/problem+json";
            var data = Encoding.ASCII.GetBytes(JsonCovertExtension.SerializeObject(response));
            await httpContext.Response.Body.WriteAsync(data, 0, data.Length);
        }

        private ErrorResponse ParseErrorResponse(Exception ex, ErrorCodes errorCode = ErrorCodes.UnknownError) =>
            new ErrorResponse
            {
                Message = ex.Message,
                Code = ((ErrorCodes)(ex.Data["ErrorCode"] ?? errorCode)).GetEnumDescription()
            };
    }
}