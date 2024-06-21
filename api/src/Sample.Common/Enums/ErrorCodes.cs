using System.ComponentModel;

namespace Sample.Common.Enums
{
    public enum ErrorCodes
    {
        [Description("NOT_FOUND")]
        NotFound,
        [Description("INVALID_ARG")]
        InvalidArg,
        [Description("UNAUTHORIZED")]
        Unauthorized,
        [Description("INVALID_REQUEST_ARG")]
        InvalidRequestArg,
        [Description("UNKNOWN_ERROR")]
        UnknownError,
    }
}