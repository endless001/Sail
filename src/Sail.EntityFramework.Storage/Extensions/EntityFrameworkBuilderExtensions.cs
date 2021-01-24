using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sail.Configuration.DependencyInjection;
using Sail.EntityFramework.Storage.DbContexts;
using Sail.EntityFramework.Storage.Interfaces;
using Sail.EntityFramework.Storage.Options;
using Sail.EntityFramework.Storage.Stores;

namespace Sail.EntityFramework.Storage.Extensions
{
    public static class EntityFrameworkBuilderExtensions
    {
        /// <returns></returns>
        public static ISailBuilder AddConfigurationStore(
            this ISailBuilder builder,
            Action<ConfigurationStoreOptions> storeOptionsAction = null)
        {
            return builder.AddConfigurationStore<ConfigurationDbContext>(storeOptionsAction);
        }

        private static ISailBuilder AddConfigurationStore<TContext>(
            this ISailBuilder builder,
            Action<ConfigurationStoreOptions> storeOptionsAction = null)
            where TContext : DbContext, IConfigurationDbContext
        { 
            builder.Services.AddConfigurationDbContext<TContext>(storeOptionsAction);
            builder.AddTenantStore<TenantStore>();
            
            return builder;
        }
    }
}