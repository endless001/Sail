using Sail.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    
    public class CompositePluginProviders : IPlugin
    {
        private readonly List<IPlugin> _plugins;
        public CompositePluginProviders(params IPlugin[] plugins)
        {
            _plugins = plugins.ToList();
        }

        public bool IsInitialized { get; private set; }

        public PluginModel Get(string name, Version version)
        {
            foreach (var pluginModel in _plugins)
            {
                var plugin = pluginModel.Get(name, version);

                if (plugin == null)
                {
                    continue;
                }
                return plugin;
            }
            return null;
        }

        public List<PluginModel> GetPlugins()
        {
            var result = new List<PluginModel>();

            foreach (var plugin in _plugins)
            {
                var pluginModels = plugin.GetPlugins();
                result.AddRange(pluginModels);
            }
            return result;
        }


        public void AddCatalog(IPlugin plugin)
        {
            _plugins.Add(plugin);
        }


        public async Task Initialize()
        {
            if (_plugins?.Any() != true)
            {
                IsInitialized = true;

                return;
            }

            foreach (var plugin in _plugins)
            {
                await plugin.Initialize();
            }

            IsInitialized = true;
        }
    }
}
