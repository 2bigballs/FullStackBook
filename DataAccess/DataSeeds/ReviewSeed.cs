using Domain.Entities;

namespace DataAccess.DataSeeds
{
    public class ReviewSeed
    {
        public static IEnumerable<Review> Data()
        {
            List<Review> data = new()
            {
                new Review {Id = 1,BookId =1 ,Message="Good",Reviewer = "Illia"},
                new Review {Id = 2,BookId =2 ,Message="Well",Reviewer = "Vitalik"},
                new Review {Id = 3,BookId =3 ,Message="Bad",Reviewer = "Denys"},
                new Review {Id = 4,BookId =4 ,Message="SO-SO",Reviewer = "Dima"},
                new Review {Id = 5,BookId =5 ,Message="AWESOME",Reviewer = "Mark"},
                new Review {Id = 6,BookId =6 ,Message="EXCELLENT",Reviewer = "Oleg"},
                new Review {Id = 7,BookId =7 ,Message="BRAVO",Reviewer = "Vika"},
                new Review {Id = 8,BookId =1 ,Message="OMG",Reviewer = "Sophia"},
                new Review {Id = 9,BookId =1 ,Message="ohhh shitt",Reviewer = "Dasha"},
                new Review {Id = 10,BookId =1 ,Message="not bad",Reviewer = "Hermiona"},
                new Review {Id = 11,BookId =1 ,Message="Love it",Reviewer = "Ron"},
                new Review {Id = 12,BookId =1 ,Message="Amazing",Reviewer = "Hagrid"},
                new Review {Id = 13,BookId =1 ,Message="pooorrr",Reviewer = "Snape"},
                new Review {Id = 14,BookId =1 ,Message="no recommended this",Reviewer = "Maggongle"},
                new Review {Id = 15,BookId =1 ,Message="great",Reviewer = "Volandemort"},
                new Review {Id = 16,BookId =1 ,Message="funny",Reviewer = "Harry"}
            };
            return data;
        }
    }
}
