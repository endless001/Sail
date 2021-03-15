﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.ReverseProxy.Service;
using StackExchange.Redis;
using System;

namespace Sail.Configuration.DependencyInjection
{
    public static class StoreConfigProviderExtensions
    {
        public static IReverseProxyBuilder  LoadFromStore(this IReverseProxyBuilder  builder, Action<RedisCacheOptions> setupAction)
        {

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            builder.Services.AddOptions();
            builder.Services.Configure(setupAction);
            builder.Services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var configuration = ConfigurationOptions.Parse("47.103.25.179:6379", true);
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