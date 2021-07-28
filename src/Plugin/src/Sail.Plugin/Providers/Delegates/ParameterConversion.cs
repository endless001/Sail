using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Plugin.Providers.Delegates
{
    public class ParameterConversion
    {
        public bool ToConstructor { get; set; }
        public bool ToPublicProperty { get; set; }
        public string Name { get; set; }
    }
}
