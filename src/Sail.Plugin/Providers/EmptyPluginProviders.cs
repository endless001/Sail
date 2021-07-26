using Sail.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    public class EmptyPluginProviders : IPlugin
    {
        public bool IsInitialized { get; } = true;

        public PluginModel Get(string name, Version version)
        {
            return null;
        }

        public List<PluginModel> GetPlugins()
        {
            return new List<PluginModel>();
        }

        public Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}
