using System;
using System.Reflection;
using Sail.Plugin.TypeFinding;

namespace Sail.Plugin.Context
{
    public class MetadataTypeFindingContext : ITypeFindingContext
    {

        public Assembly FindAssembly(string assemblyName)
        {
            throw new NotImplementedException();
        }

        public Type FindType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
