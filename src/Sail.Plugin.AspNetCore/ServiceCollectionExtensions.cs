using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sail.Plugin.Abstractions;

namespace Sail.Plugin.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlugin(this IServiceCollection services, Action<PluginOptions> configure = null)
        {
            return services;
        }
    }
}
