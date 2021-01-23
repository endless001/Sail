using AutoMapper;
using Sail.Storage.Models;


namespace Sail.EntityFramework.Storage.Mappers
{
    public static class AccessControlMappers
    {
        internal static IMapper Mapper;

        static AccessControlMappers()
        {
            Mapper = new MapperConfiguration(cfg => 
                    cfg.AddProfile<AccessControlMapperProfile>())
                .CreateMapper();
        }

        public static AccessControl ToModel(this Entities.AccessControl entity)
        {
            return Mapper.Map<AccessControl>(entity);
        }

        public static Entities.AccessControl ToEntity(this AccessControl model)
        {
            return Mapper.Map<Entities.AccessControl>(model);
        }
    }
}