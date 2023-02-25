using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReviewService
    {
        Task<Response<int>> Create(Review review);
    }
}
