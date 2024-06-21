using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sample.Common.Exceptions;

namespace Sample.Api.Validators
{
    public class ValidationFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
            var modelState = context.ModelState;

            if (!modelState.IsValid)
            {
                var entry = modelState.Values.FirstOrDefault(x => x.ValidationState == ModelValidationState.Invalid);
                var message = entry == null ? "Input validation failed for parameter value" : entry.Errors.FirstOrDefault()?.ErrorMessage;
                throw new ValidationException(message);
            }
        }
    }
}