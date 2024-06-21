using System.Collections.Generic;
using System.Linq;
using System.Net;
using Sample.Common.Enums;
using Sample.Common.Extensions;

namespace Sample.Api.Responses
{
    /// <summary>
    /// response result dto base
    /// </summary>
    /// <typeparam name="T">Dto</typeparam>
    public class ApiResponse<T> : ResponseBase where T : class
    {
        /// <summary>
        /// response data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// parse response object from dto input
        /// </summary>
        /// <param name="data"></param>
        /// <returns>ApiResponse</returns>
        public static ApiResponse<T> ParseResponse(T data) =>
            IsNullOrEmpty(data)
                ? new ApiResponse<T> { StatusCode = HttpStatusCode.NotFound, Error = new ErrorResponse { Code = ErrorCodes.NotFound.GetEnumDescription(), Message = "the server could not find what was requested" } }
                : new ApiResponse<T> { StatusCode = HttpStatusCode.OK, Data = data };

        /// <summary>
        /// parse response object from dto input
        /// </summary>
        /// <param name="data"></param>
        /// <param name="code"></param>
        /// <returns>ApiResponse</returns>
        public static ApiResponse<T> ParseResponse(T data, HttpStatusCode code) =>
            new ApiResponse<T>
            {
                Data = data,
                StatusCode = code,
            };

        private static bool IsNullOrEmpty(T data) =>
            data == null || data is IEnumerable<object> objects && !objects.Any();
    }
}