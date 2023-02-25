using Application.Extensions;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(p => p.Author).Required()
                .MatchName();

            RuleFor(p=>p.Title).Required()
                .MaximumLength(50).WithMessage($"Genre must contains maximum 50 symbols");

            RuleFor(p => p.Genre).Required()
                .MatchName()
                .Length(3,25).WithMessage($"Genre must contains minimum 3 and maximum 25 symbols");

            RuleFor(p => p.Cover).Required();

            RuleFor(p => p.Content).Required()
                .Length(10,1000).WithMessage($"Content must contains minimum 10 and maximum 1000 symbols");
        }
    }
}
