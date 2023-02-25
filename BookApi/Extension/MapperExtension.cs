using MapsterMapper;

namespace BookApi.Extension
{
    public static class MapperExtension
    {
        public static TAdaptType AddParameters<TAdaptType,T>(this IMapper mapper,T source,params (string name, object obj)[] parameters)
        {
            var mapFrom = mapper.From(source);
            foreach (var param in parameters)
            {
                mapFrom=mapFrom.AddParameters(param.name, param.obj);
            }
            return mapFrom.AdaptToType<TAdaptType>();
        }
    }
}
