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
            return builder;
        }
       
    }
}