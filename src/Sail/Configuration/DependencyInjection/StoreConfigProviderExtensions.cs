using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.ReverseProxy.Service;
using StackExchange.Redis;

namespace Sail.Configuration.DependencyInjection
{
    public static class StoreConfigProviderExtensions
    {
        public static IReverseProxyBuilder  LoadFromStore(this IReverseProxyBuilder  builder,IConfiguration configuration)
        {
            builder.Services.Configure<RedisConfig>(configuration.GetSection("RedisConfig"));
            
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