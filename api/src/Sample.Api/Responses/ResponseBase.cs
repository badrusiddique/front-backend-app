using System.Net;

namespace Sample.Api.Responses
{
    /// <summary>
    /// response result base
    /// </summary>
    public class ResponseBase
    {
        /// <summary>
        /// http status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        /// <summary>
        /// error response with message and error-code
        /// </summary>
        public ErrorResponse Error { get; set; }

        /// <summary>
        /// parse default response
        /// </summary>
        /// <returns>ApiResponse</returns>
        public static ResponseBase DefaultResponse() => new ResponseBase();

        /// <summary>
        /// parse response with input
        /// </summary>
        /// <returns>ApiResponse</returns>
        public static ResponseBase ParseResponse(HttpStatusCode code, ErrorResponse error) =>
            new ResponseBase
            {
                StatusCode = code,
                Error = error
            };
    }
}