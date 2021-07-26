using Sail.Plugin.Abstractions;
using Sail.Plugin.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    public class AssemblyPluginProviders : IPlugin
    {
        private readonly string _assemblyPath;
        private readonly Assembly _assembly;
        private readonly AssemblyPluginOptions _options;
        private PluginAssemblyLoadContext _pluginAssemblyLoadContext;
      //  private List<TypePlugin> _plugins = null;

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
