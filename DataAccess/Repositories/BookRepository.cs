using System.Linq.Expressions;
using Application.Interfaces;
using DataAccess.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Reposetories
{

    public class BookRepository : GenericRepository<Book>,IBookRepository
    {
        public BookRepository(ApplicationContext db) : base(db)
        {
            
        }
        public async Task<List<Book>> GetAll<TKey>(Expression<Func<Book, TKey>> orderBy)
        {
            IQueryable<Book> bookQuery = _db.Books.Include(x => x.Ratings).Include(x => x.Reviews);
            if (orderBy != null)
            {
                bookQuery = bookQuery.OrderBy(orderBy);
            }

            var books= await bookQuery.ToListAsync();

            return books;
        }
        public async Task<List<Book>> GetRecommended(int reviewCount, string? genre, int bookCount)
        {
            
            IQueryable<Book> bookQuery = _db.Books.Include(x => x.Reviews).Include(x => x.Ratings);

           var recommendedBooks = await bookQuery
                .Where(x => x.Reviews.Count >= reviewCount && (genre == null || x.Genre.ToLower() == genre.ToLower()))
                .OrderByDescending(x => x.Ratings.Average(y => y.Score))
                .Take(bookCount).ToListAsync();
            return recommendedBooks;
        }
        public async Task<Book?> GetBookById(int id)
        {
            IQueryable<Book> bookQuery = _db.Books.AsNoTracking().Include(x => x.Reviews).Include(x=>x.Ratings);
            var book = await bookQuery.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }
        public async Task RemoveById(int id)
        {
            var book = await _db.Books.FindAsync(id);
            _db.Books.Remove(book);
           
        }
        public  void Update(Book book)
        {
            _db.Books.Update(book);
            
        }
        public async Task<bool> IsExist(int id)
        {
            bool isExist = await _db.Books.AnyAsync(x => x.Id == id);
            return isExist;
        }
    }

}
