using Sail.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    class TypePluginProviders : IPlugin
    {
        private readonly Type _pluginType;
       // private readonly TypePluginOptions _options;
        private PluginModel _plugin;
        public bool IsInitialized => throw new NotImplementedException();

        public PluginModel Get(string name, Version version)
        {
            throw new NotImplementedException();
        }

        public List<PluginModel> GetPlugins()
        {
            throw new NotImplementedException();
        }

        public Task Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
