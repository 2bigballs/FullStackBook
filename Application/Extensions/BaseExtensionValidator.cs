using Application.Interfaces;
using FluentValidation;

namespace Application.Extensions
{
    public static class BaseExtensionValidator
    {
        public static IRuleBuilderOptions<T, int> ExistById<T>(this IRuleBuilder<T, int> ruleBuilder, IBookRepository bookRepository)
        {
            return ruleBuilder.MustAsync(async (id, cancellationToken) => await bookRepository.IsExist(id));
        }

        public static IRuleBuilderOptions<T, string> MatchName<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Matches(@"^[A-Za-z -]+$").WithMessage("{PropertyName} name must contains only latin letters");
        }

        public static IRuleBuilderOptions<T, string> Required<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotEmpty().WithMessage("{PropertyName} must be required");
        }
    }
}
