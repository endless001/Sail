using System;
using Sail.Plugin.Context;
using Sail.Plugin.TypeFinding;
using System.Collections.Generic;
using Sail.Plugin.Abstractions;

namespace Sail.Plugin.Providers
{
    public class FolderPluginOptions
    {
        public bool IncludeSubfolders { get; set; } = true;
        public List<string> SearchPatterns { get; set; } = new List<string>() { "*.dll" };
        public PluginLoadContextOptions PluginLoadContextOptions { get; set; } = new PluginLoadContextOptions();

        [Obsolete("Please use TypeFinderOptions. This will be removed in a future release.")]
        public TypeFinderCriteria TypeFinderCriteria { get; set; }

        [Obsolete("Please use TypeFinderOptions. This will be removed in a future release.")]
        public Dictionary<string, TypeFinderCriteria> TypeFinderCriterias { get; set; } = new Dictionary<string, TypeFinderCriteria>();

        public TypeFinderOptions TypeFinderOptions { get; set; } = new TypeFinderOptions();

        public PluginNameOptions PluginNameOptions { get; set; } = Defaults.PluginNameOptions;

        public static class Defaults
        {
            public static PluginNameOptions PluginNameOptions { get; set; } = new PluginNameOptions();
        }
    }
}
