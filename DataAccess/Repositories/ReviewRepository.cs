using Application.Interfaces;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class ReviewRepository: GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationContext db):base(db)
        {
        }
    }
}
