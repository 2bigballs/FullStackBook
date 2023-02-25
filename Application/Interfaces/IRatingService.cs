using Application.Models;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRatingService
    {
        Task<Response<int>> Create(Rating rating);
    }
}
