using Microsoft.Extensions.DependencyInjection.Extensions;
using Sail.Configuration.DependencyInjection;
using Sail.Storage.Stores;

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