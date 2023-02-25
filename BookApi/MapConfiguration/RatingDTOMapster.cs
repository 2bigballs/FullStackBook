
using Contract.RatingDTOs;
using Domain.Entities;
using Mapster;

namespace BookApi.MapsterConfiguration
{
    public class RatingDTOMapster : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateRateDTO,Rating>()
                .Map(dst=>dst.BookId,
                    src=> MapContext.Current.Parameters["bookId"]);
        }
    }
}
