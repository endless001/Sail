using Sail.Plugin.Abstractions;
using Sail.Plugin.TypeFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers
{
    public class TypePluginOptions
    {
        public PluginNameOptions PluginNameOptions { get; set; } = Defaults.PluginNameOptions;

        [Obsolete("Please use TypeFinderOptions. This will be removed in a future release.")]
        public Dictionary<string, TypeFinderCriteria> TypeFinderCriterias = new Dictionary<string, TypeFinderCriteria>();
        public TypeFinderOptions TypeFinderOptions { get; set; } = new TypeFinderOptions();
        public ITypeFindingContext TypeFindingContext { get; set; } = null;
        public static class Defaults
        {
            public static PluginNameOptions PluginNameOptions { get; set; } = new PluginNameOptions();
        }

    }
}
