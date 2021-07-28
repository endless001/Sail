using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Configuration.Loaders
{
    public interface IPluginConfigurationLoader
    {
        string Key { get; }
        List<PluginConfiguration> GetPluginConfigurations(IConfiguration configuration);

    }
}
