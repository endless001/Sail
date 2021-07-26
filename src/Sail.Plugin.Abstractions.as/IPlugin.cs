using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sail.Plugin.Abstractions
{
    public interface IPlugin
    {
        Task Initialize();
        bool IsInitialized { get; }
        List<PluginModel> GetPlugins();
        PluginModel Get(string name, Version version);
    }
}
