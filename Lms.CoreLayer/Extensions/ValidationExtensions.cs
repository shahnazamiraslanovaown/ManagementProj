using FluentValidation.Results;
using Lms.CoreLayer.Wrappers.Concrete;

namespace Lms.CoreLayer.Extensions
{
    public static class ValidationExtensions
    {
        public static List<ResponseValidationResult> ToResponseValidationResults(this ValidationResult validationResult)
        {
            List<ResponseValidationResult> responseValidationResults = [];

            foreach (var item in validationResult.Errors)
            {
                responseValidationResults.Add(new()
                {
                    ErrorMessage = item.ErrorMessage,
                    PropertyName = item.PropertyName,
                });
            }

            return responseValidationResults;
        }
    }
}
