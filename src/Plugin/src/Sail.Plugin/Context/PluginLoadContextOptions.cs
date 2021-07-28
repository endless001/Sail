using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Context
{
    public class PluginLoadContextOptions
    {
        public UseHostApplicationAssembliesEnum UseHostApplicationAssemblies { get; set; } = Defaults.UseHostApplicationAssemblies;
        public List<AssemblyName> HostApplicationAssemblies { get; set; } = Defaults.HostApplicationAssemblies;
        public Func<ILogger<PluginAssemblyLoadContext>> LoggerFactory { get; set; } = Defaults.LoggerFactory;
        public List<string> AdditionalRuntimePaths { get; set; } = Defaults.AdditionalRuntimePaths;
        public List<RuntimeAssemblyHint> RuntimeAssemblyHints { get; set; } = Defaults.RuntimeAssemblyHints;
        public static class Defaults
        {
            public static UseHostApplicationAssembliesEnum UseHostApplicationAssemblies { get; set; } = UseHostApplicationAssembliesEnum.Always;
            public static List<AssemblyName> HostApplicationAssemblies { get; set; } = new List<AssemblyName>();
            public static Func<ILogger<PluginAssemblyLoadContext>> LoggerFactory { get; set; } = () => NullLogger<PluginAssemblyLoadContext>.Instance;
            public static List<string> AdditionalRuntimePaths { get; set; } = new List<string>();
            public static List<RuntimeAssemblyHint> RuntimeAssemblyHints { get; set; } = new List<RuntimeAssemblyHint>();
        }
    }

  
}
