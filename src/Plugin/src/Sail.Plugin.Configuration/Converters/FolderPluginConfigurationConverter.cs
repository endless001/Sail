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
    public class FolderPluginConfigurationConverter : IConfigurationToPluginConverter
    {
        public bool CanConvert(string type)
        {
            return string.Equals(type, "Folder", StringComparison.InvariantCultureIgnoreCase);
        }

        public IPlugin Convert(IConfigurationSection configuration)
        {
            var path = configuration.GetValue<string>("Path")?? throw new ArgumentException("Plugin Framework's FolderCatalog requires a Path.");

            var options = new PluginFolderOptions();
            configuration.Bind($"Options", options);

            var folderOptions = new FolderPluginOptions();

            folderOptions.IncludeSubfolders = options.IncludeSubfolders ?? folderOptions.IncludeSubfolders;
            folderOptions.SearchPatterns = options.SearchPatterns ?? folderOptions.SearchPatterns;

            return new FolderPluginProviders(path, folderOptions);
        }
        private class PluginFolderOptions
        {
            public bool? IncludeSubfolders { get; set; }
            public List<string> SearchPatterns { get; set; }
        }
    }

}
