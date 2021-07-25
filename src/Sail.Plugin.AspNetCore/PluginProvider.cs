using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sail.Plugin.Abstractions;

namespace Sail.Plugin.AspNetCore
{
  public class PluginProvider
  {
    private readonly IEnumerable<IPlugin> _plugins;
    private readonly IServiceProvider _serviceProvider;

    public PluginProvider(IEnumerable<IPlugin> plugins,IServiceProvider serviceProvider)
    {
      _plugins = plugins;
      _serviceProvider = serviceProvider;
    }

    public List<Abstractions.Plugin> GetByTag(string tag)
    {
      var result = new List<Abstractions.Plugin>();
      foreach (var plugin in _plugins)
      {
        var pluginsByTag = plugin.GetByTag(tag);
        result.AddRange(pluginsByTag);
      }
      return result;
    }

    public List<Abstractions.Plugin> GetPlugins()
    {
      var result = new List<Abstractions.Plugin>();
      foreach (var plugin in _plugins)
      {
        result.AddRange(plugin.GetPlugins());
      }
      return result;
    }
    public Abstractions.Plugin Get(string name, Version version)
    {
      foreach (var plugin in _plugins)
      {
        var result = plugin.Get(name, version);

        if (result != null)
        {
          return result;
        }
      }
      return null;
    }
    public List<T> GetTypes<T>() where T : class
    {
      var result = new List<T>();
      var pluginServices = _serviceProvider.GetServices<IPlugin>();

      foreach (var service in pluginServices)
      {
        var plugins = service.GetPlugins();

        foreach (var plugin in plugins.Where(x => typeof(T).IsAssignableFrom(x)))
        {
          var op = plugin.Create<T>(_serviceProvider);
          result.Add(op);
        }
      }

      return result;
    }
  }
}
