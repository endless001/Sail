using Sail.Storage.Stores;
using Sail.Configuration.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SailBuilderExtensionsAdditional
    {
        public static ISailBuilder AddTenantStore<T>(this ISailBuilder builder)
            where T : class, ITenantStore
        {
            builder.Services.TryAddTransient(typeof(T));
            builder.Services.AddTransient<ITenantStore,T>();
            return builder;
        }

        public static ISailBuilder AddServiceStore<T>(this ISailBuilder builder)
          where T : class, IServiceStore
        {
            builder.Services.TryAddTransient(typeof(T));
            builder.Services.AddTransient<IServiceStore, T>();
            return builder;
        }

        public static ISailBuilder AddAccessControlStore<T>(this ISailBuilder builder)
             where T : class, IAccessControlStore
        {
            builder.Services.TryAddTransient(typeof(T));
            builder.Services.AddTransient<IAccessControlStore, T>();
            return builder;
        }
    }
}