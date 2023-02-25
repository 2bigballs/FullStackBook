using Contract.ReviewDTOs;
using Domain.Entities;
using Mapster;

namespace BookApi.MapConfiguration
{
    public class ReviewDTOMapster : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateReviewDTO, Review>()
                .Map(dst => dst.BookId,
                    src => MapContext.Current.Parameters["bookId"]);
        }
    }
}
