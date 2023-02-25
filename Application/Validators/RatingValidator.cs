using Application.Extensions;
using Application.Interfaces;
using Domain.Entities;
using FluentValidation;

namespace Application.Validators
{
    public class RatingValidator : AbstractValidator<Rating>
    {
        private readonly IBookRepository _bookRepository;
        public RatingValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            RuleFor(p=>p.Score).ExclusiveBetween(0,6).WithMessage($"Score must be between 1 to 5 ");

            RuleFor(p => p.BookId).ExistById(_bookRepository).WithMessage(p=>$"Not found book by id {p.BookId}");
        }
    }
}
