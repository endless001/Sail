using System;
using System.Reflection;

namespace Sail.Plugin.TypeFinding
{
  public interface ITypeFindingContext
  {
    Assembly FindAssembly(string assemblyName);
    Type FindType(Type type);
  }
}
