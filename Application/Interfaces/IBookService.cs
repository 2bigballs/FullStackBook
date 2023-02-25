using Application.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks(string? orderBy);

        Task<List<Book>> GetRecommendedBook(string? genre);

        Task<Response<Book>?> GetBookDetails(int id);

        Task<Response<int>> Create(Book book,IFormFile file);

        Task<Response<EmptyValue>> Remove(int id, string key);

        Task<Response<EmptyValue>> Update(Book book, IFormFile file);
    }

}
