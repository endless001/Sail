using Sail.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    public class FolderPluginProviders : IPlugin
    {
        public bool IsInitialized { get; private set; }

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
