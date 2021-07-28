using Sail.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers.Delegates
{
    public class DelegatePlugin : IPlugin
    {
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
