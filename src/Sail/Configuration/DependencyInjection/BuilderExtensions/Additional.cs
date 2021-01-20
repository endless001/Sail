using Microsoft.Extensions.Configuration;
using Sail.Storage.Stores;
using Sail.Configuration.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.ReverseProxy.Service;
using Sail.Configuration;
using StackExchange.Redis;

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
        
        public static ISailBuilder AddReverseProxy(this ISailBuilder builder,IConfiguration configuration)
        {
            builder.Services.Configure<RedisConfig>(configuration);
            
            builder.Services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var redisConfig = sp.GetRequiredService<IOptions<RedisConfig>>().Value;
                var configuration = ConfigurationOptions.Parse(redisConfig.ConnectionString, true);
                
                configuration.ResolveDns = true;

                return ConnectionMultiplexer.Connect(configuration);
            });
            
            builder.Services.AddSingleton<IProxyConfigProvider>(sp =>
            {
                var logger = sp.GetService<ILogger<StoreConfigProvider>>();
                var connection = sp.GetService<ConnectionMultiplexer>();
                return new StoreConfigProvider(logger, connection);
            });
            
            return builder;
        }
    }
}