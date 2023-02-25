using Domain.Entities;

namespace DataAccess.DataSeeds
{
    public class RatingSeed
    {
        public static IEnumerable<Rating> Data()
        {
            List<Rating> data = new ()
            {
                new Rating {Id = 1,BookId = 1,Score = 3},
                new Rating {Id = 2,BookId = 2,Score = 2},
                new Rating {Id = 3,BookId = 3,Score = 5},
                new Rating {Id = 4,BookId = 4,Score = 1},
                new Rating {Id = 5,BookId = 5,Score = 4},
                new Rating {Id = 6,BookId = 6,Score = 3},
                new Rating {Id = 7,BookId = 7,Score = 2},
                new Rating {Id = 8,BookId = 1,Score = 3},
                new Rating {Id = 9,BookId = 2,Score = 1},
                new Rating {Id = 10,BookId = 3,Score = 4},
                new Rating {Id = 11,BookId = 4,Score = 4},
                new Rating {Id = 12,BookId = 5,Score = 4},
                new Rating {Id = 13,BookId = 6,Score = 5},
                new Rating {Id = 14,BookId = 7,Score = 5},
                new Rating {Id = 15,BookId = 1,Score = 5},
                new Rating {Id = 16,BookId = 2,Score = 3},
                new Rating {Id = 17,BookId = 3,Score = 2},
                new Rating {Id = 18,BookId = 4,Score = 3},
                new Rating {Id = 19,BookId = 5,Score = 4},
                new Rating {Id = 20,BookId = 6,Score = 3}
            };
            return data;
        }
    }
}
