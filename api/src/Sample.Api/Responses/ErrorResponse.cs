using Sample.Common.Enums;
using Sample.Common.Extensions;

namespace Sample.Api.Responses
{
    /// <summary>
    /// error response
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// error message
        /// </summary>
        public string Message { get; set; } = "The server encountered an internal unknown error";

        /// <summary>
        /// error code
        /// </summary>
        public string Code { get; set; } = ErrorCodes.UnknownError.GetEnumDescription();
    }
}