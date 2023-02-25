using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<List<Book>> GetAll<TKey>(Expression<Func<Book, TKey>> orderBy);

        Task<List<Book>> GetRecommended(int reviewCount, string? genre, int bookCount);

        Task<Book?> GetBookById(int id);

        Task RemoveById(int id);

        void Update(Book book);

        Task<bool> IsExist(int id);
    }
}
