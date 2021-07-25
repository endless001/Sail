using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sail.Plugin.Abstractions
{
  public class Plugin
  {
    public string Name { get; set; }
    public Version Version { get; set; }
    public Type Type { get; set; }
    public Assembly Assembly { get; set; }
    public IPlugin Source { get; set; }
    public string Description { get; set; }
    public string ProductVersion { get; set; }
    public List<string> Tags { get; set; }

    public string Tag => Tags.FirstOrDefault();

    public Plugin(Assembly assembly, Type type, string name, Version version, IPlugin source,
      string description, string productVersion,
      string tag, List<string> tags)
    {
      Assembly = assembly;
      Type = type;
      Name = name;
      Version = version;
      Source = source;
      Description = description;
      ProductVersion = productVersion;
      Tags = tags ?? new List<string>();

      if (!string.IsNullOrWhiteSpace(tag))
      {
        Tags.Add(tag);
      }
    }

    public static implicit operator Type(Plugin plugin)
    {
      return plugin.Type;
    }

    public override string ToString()
    {
      return $"{Name}: {Version}";
    }
  }
}
