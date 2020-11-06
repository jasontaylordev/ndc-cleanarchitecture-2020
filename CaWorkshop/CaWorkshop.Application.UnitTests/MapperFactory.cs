using AutoMapper;
using CaWorkshop.Application.Common.Mappings;

namespace CaWorkshop.Application.UnitTests
{
    public static class MapperFactory
    {
        public static IMapper Create()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            return configuration.CreateMapper();
        }
    }
}