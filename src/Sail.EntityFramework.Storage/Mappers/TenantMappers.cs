using System;
using AutoMapper;

namespace Sail.EntityFramework.Storage.Mappers
{
    public class TenantMappers
    {
        internal static IMapper Mapper;
        static TenantMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<TenantMapperProfile>())
                .CreateMapper();
        }
    }
}
