using System.Collections.Generic;
using System.Linq;

namespace Sail.Plugin.Abstractions
{
  public static class IPluginExtensions
  {
    public static PluginModel Single(this IPlugin plugin)
    {
      var plugins = plugin.GetPlugins();

      return plugins.Single();
    }

    public static PluginModel Get(this IPlugin plugin)
    {
      return plugin.Single();
    }

    public static List<PluginModel> GetByTag(this IPlugin plugin, string tag)
    {
      return plugin.GetPlugins().Where(x => x.Tags.Contains(tag)).ToList();
    }
  }
}
