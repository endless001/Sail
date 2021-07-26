using System;
using Microsoft.Extensions.DependencyInjection;
using Sail.Plugin.Abstractions;

namespace Sail.Plugin.AspNetCore
{
    public static class ServiceProviderExtensions
    {
        public static object Create(this IServiceProvider serviceProvider, PluginModel plugin)
        {
            return ActivatorUtilities.CreateInstance(serviceProvider, plugin);
        }

        public static T Create<T>(this IServiceProvider serviceProvider, PluginModel plugin) where T : class
        {
            return ActivatorUtilities.CreateInstance(serviceProvider, plugin) as T;
        }
    }
}
