using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sail.Plugin.AspNetCore
{
  public static class ServiceProviderExtensions
  {
    public static object Create(this IServiceProvider serviceProvider, Abstractions.Plugin plugin)
    {
      return ActivatorUtilities.CreateInstance(serviceProvider, plugin);
    }

    public static T Create<T>(this IServiceProvider serviceProvider, Abstractions.Plugin plugin) where T : class
    {
      return ActivatorUtilities.CreateInstance(serviceProvider, plugin) as T;
    }
  }
}
