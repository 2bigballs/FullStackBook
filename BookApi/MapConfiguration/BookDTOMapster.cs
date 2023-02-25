using Contract.BookDTOs;
using Domain.Entities;
using Mapster;
using System.Linq.Expressions;

namespace BookApi.MapsterConfiguration
{
    public class BookDTOMapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Book, GetBooksDTO>()
                .Map(dst => dst.ReviewsNumber, src => src.Reviews.Count)
                .AverageRatingMapping(dst => dst.Rating);

            config.NewConfig<Book, RecommendedBookDTO>()
                .Map(dst => dst.ReviewsNumber, src => src.Reviews.Count)
                .AverageRatingMapping(dst => dst.Rating);

            config.NewConfig<Book, GetBookDetailsDTO>().AverageRatingMapping(dst => dst.Rating);
        }
    }

    public static class NewConfigExtension
    {
        public static TypeAdapterSetter<Book, TDestination> AverageRatingMapping<TDestination, TDestinationMember>(
            this TypeAdapterSetter<Book, TDestination> config, Expression<Func<TDestination, TDestinationMember>> member)
        {
            config.Map(member, 
                src => src.Ratings.Average(y => y.Score),
                srcCond => srcCond.Ratings.Any());
            return config;
        }
    }
}
