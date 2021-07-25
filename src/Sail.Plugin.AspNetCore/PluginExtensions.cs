using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sail.Plugin.AspNetCore
{
  public static class PluginExtensions
  {
    public static object Create(this Abstractions.Plugin plugin, IServiceProvider serviceProvider, params object[] parameters)
    {
      return ActivatorUtilities.CreateInstance(serviceProvider, plugin, parameters);
    }
    public static T Create<T>(this Abstractions.Plugin plugin, IServiceProvider serviceProvider, params object[] parameters) where T : class
    {
      return ActivatorUtilities.CreateInstance(serviceProvider, plugin, parameters) as T;
    }  }
}
