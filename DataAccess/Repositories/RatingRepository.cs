using Application.Interfaces;
using Domain.Entities;

namespace DataAccess.Repositories
{
    public class RatingRepository : GenericRepository<Rating>,IRatingRepository
    {
        public RatingRepository(ApplicationContext db):base(db)
        {
        }
    }
}
