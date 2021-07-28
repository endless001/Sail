using Sail.Plugin.Abstractions;
using Sail.Plugin.Context;
using Sail.Plugin.TypeFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    public class AssemblyPluginOptions
    {
        public PluginLoadContextOptions PluginLoadContextOptions = new PluginLoadContextOptions();

        [Obsolete("Please use TypeFinderOptions. This will be removed in a future release.")]
        public Dictionary<string, TypeFinderCriteria> TypeFinderCriterias = new Dictionary<string, TypeFinderCriteria>();
        public PluginNameOptions PluginNameOptions { get; set; } = Defaults.PluginNameOptions;
        public TypeFinderOptions TypeFinderOptions { get; set; } = new TypeFinderOptions();
        public static class Defaults
        {
            public static PluginNameOptions PluginNameOptions { get; set; } = new PluginNameOptions();
        }
    }
}
