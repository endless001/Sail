using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Sail.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Configuration.Loaders
{
    public class PluginConfigurationLoader : IPluginConfigurationLoader
    {
        public string Key => "Plugins";
        private PluginOptions _options;

        public PluginConfigurationLoader(IOptions<PluginOptions> options)
        {
            _options = options.Value;
        }

        public List<PluginConfiguration> GetPluginConfigurations(IConfiguration configuration)
        {
            var plugins = new List<PluginConfiguration>();

            configuration.Bind($"{_options.ConfigurationSection}:{Key}", plugins);

            return plugins;
        }
    }
}
