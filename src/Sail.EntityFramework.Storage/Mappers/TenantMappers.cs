using System;
using AutoMapper;
using Sail.Storage.Models;

namespace Sail.EntityFramework.Storage.Mappers
{
    public static class TenantMappers
    {
        internal static IMapper Mapper;
        static TenantMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<TenantMapperProfile>())
                .CreateMapper();
        }
        public static Tenant ToModel(this Entities.Tenant entity)
        {
            return Mapper.Map<Tenant>(entity);
        }

        public static Entities.Tenant ToEntity(this Tenant entity)
        {
            return Mapper.Map<Entities.Tenant>(entity);
        }

    }
}
