using System.Collections.Generic;
using System.Linq;

namespace Sail.Plugin.Abstractions
{
  public static class IPluginExtensions
  {
    public static Plugin Single(this IPlugin plugin)
    {
      var plugins = plugin.GetPlugins();

      return plugins.Single();
    }

    public static Plugin Get(this IPlugin plugin)
    {
      return plugin.Single();
    }

    public static List<Plugin> GetByTag(this IPlugin plugin, string tag)
    {
      return plugin.GetPlugins().Where(x => x.Tags.Contains(tag)).ToList();
    }
  }
}
