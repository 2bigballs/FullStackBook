using Application.Extensions;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using FluentValidation;

namespace Application.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IValidator<Rating> _ratingValidator;

        public RatingService(IRatingRepository ratingRepository, IValidator<Rating> ratingValidator)
        {
            _ratingRepository = ratingRepository;
            _ratingValidator = ratingValidator;
        }

        public async Task<Response<int>> Create(Rating rating)
        {
            var validationResponse = await _ratingValidator.ValidateAsync(rating);
            if (!validationResponse.IsValid)
            {
                return FailureResponses.BadRequest<int>(validationResponse.ErrorMessages());
            }
            await _ratingRepository.Create(rating);
            await _ratingRepository.SaveChanges();
            return SuccessResponses.Created(rating.Id);
        }
    }
}
