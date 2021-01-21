using AutoMapper;
using Sail.Storage.Models;
namespace Sail.EntityFramework.Storage.Mappers
{
    public static class ServiceMappers
    {
        internal static IMapper Mapper;

        static ServiceMappers()
        {
            Mapper = new MapperConfiguration(cfg => 
                    cfg.AddProfile<ServiceMapperProfile>())
                .CreateMapper();
        }

        public static Service ToModel(this Entities.Service entity)
        {
            return Mapper.Map<Service>(entity);
        }

        public static Entities.Service ToEntity(this Service model)
        {
            return Mapper.Map<Entities.Service>(model);
        }

    }
}