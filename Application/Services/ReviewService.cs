using Application.Extensions;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using FluentValidation;

namespace Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IValidator<Review> _reviewValidator;
        public ReviewService(IReviewRepository reviewRepository, IValidator<Review> reviewValidator)
        {
            _reviewRepository = reviewRepository;
            _reviewValidator = reviewValidator;
        }
       
        public async Task<Response<int>> Create(Review review)
        {
            var validationResponse = await _reviewValidator.ValidateAsync(review);
            if (!validationResponse.IsValid)
            {
                return FailureResponses.BadRequest<int>(validationResponse.ErrorMessages());
            }

            await _reviewRepository.Create(review);
            await _reviewRepository.SaveChanges();
            return SuccessResponses.Created(review.Id);
        }
    }
}
