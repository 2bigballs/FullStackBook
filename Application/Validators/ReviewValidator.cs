using Application.Extensions;
using Application.Interfaces;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        private readonly IBookRepository _bookRepository;
        public ReviewValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            RuleFor(p => p.BookId).ExistById(_bookRepository)
                .WithMessage(p=>$"Not found book by id {p.BookId}");

            RuleFor(p => p.Reviewer).Required().MatchName();

            RuleFor(p => p.Message).Required()
                .Length(10, 700).WithMessage($"Message must contains minimum 10 and maximum 700 symbols");
        }
    }
}
