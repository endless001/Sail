using System;
using System.Collections.Generic;
using System.Linq;

namespace Sail.Plugin.AspNetCore
{
  public class DefaultPluginOption
  {
    public Func<IServiceProvider, IEnumerable<Type>, Type> DefaultType { get; set; }
      = (serviceProvider, implementingTypes) => implementingTypes.FirstOrDefault();
  }
}
