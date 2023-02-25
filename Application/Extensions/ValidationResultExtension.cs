using FluentValidation.Results;

namespace Application.Extensions
{
    public static class ValidationResultExtension
    {
        public static string[] ErrorMessages(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
        }
    }
}
