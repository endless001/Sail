using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace Sail.Plugin.Abstractions
{
  public class PluginNameOptions
  {

    public Func<PluginNameOptions, Type, string> PluginNameGenerator = (options, type) =>
    {
      var displayNameAttribute = type.GetCustomAttribute(typeof(DisplayNameAttribute), true) as DisplayNameAttribute;

      if (displayNameAttribute == null)
      {
        return type.FullName;
      }

      if (string.IsNullOrWhiteSpace(displayNameAttribute.DisplayName))
      {
        return type.FullName;
      }

      return displayNameAttribute.DisplayName;
    };

    public Func<PluginNameOptions, Type, Version> PluginVersionGenerator = (options, type) =>
    {
      var assemblyLocation = type.Assembly.Location;
      Version version;

      if (!string.IsNullOrWhiteSpace(assemblyLocation))
      {
        var versionInfo = FileVersionInfo.GetVersionInfo(assemblyLocation);

        if (string.IsNullOrWhiteSpace(versionInfo.FileVersion))
        {
          version = new Version(1, 0, 0, 0);
        }
        else if (string.Equals(versionInfo.FileVersion, "0.0.0.0", StringComparison.Ordinal))
        {
          version = new Version(1, 0, 0, 0);
        }
        else
        {
          version = Version.Parse(versionInfo.FileVersion);
        }
      }
      else
      {
        version = new Version(1, 0, 0, 0);
      }

      return version;
    };

    public Func<PluginNameOptions, Type, string> PluginDescriptionGenerator = (options, type) =>
    {
      var assemblyLocation = type.Assembly.Location;

      if (string.IsNullOrWhiteSpace(assemblyLocation))
      {
        return string.Empty;
      }

      var versionInfo = FileVersionInfo.GetVersionInfo(assemblyLocation);

      return versionInfo.Comments;
    };

    public Func<PluginNameOptions, Type, string> PluginProductVersionGenerator = (options, type) =>
    {
      var assemblyLocation = type.Assembly.Location;

      if (string.IsNullOrWhiteSpace(assemblyLocation))
      {
        return string.Empty;
      }

      var versionInfo = FileVersionInfo.GetVersionInfo(assemblyLocation);

      return versionInfo.ProductVersion;
    };

  }
}
