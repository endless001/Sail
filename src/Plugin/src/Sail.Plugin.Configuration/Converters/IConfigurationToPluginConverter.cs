using Microsoft.Extensions.Configuration;
using Sail.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Configuration.Converters
{
    public interface IConfigurationToPluginConverter
    {
        bool CanConvert(string type);

        IPlugin Convert(IConfigurationSection section);
    }
}
