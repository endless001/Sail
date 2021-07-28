using Microsoft.Extensions.Configuration;
using Sail.Plugin.Abstractions;
using Sail.Plugin.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Configuration.Converters
{
    public class AssemblyPluginConfigurationCoverter : IConfigurationToPluginConverter
    {

        public bool CanConvert(string type)
        {
            return string.Equals(type, "Assembly", StringComparison.InvariantCultureIgnoreCase);
        }

        public IPlugin Convert(IConfigurationSection section)
        {
            var path = section.GetValue<string>("Path");

            return new AssemblyPluginProviders(path);
        }
    }
}
