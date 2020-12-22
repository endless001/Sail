using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Values
{
    public class Service
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public ServiceUrl Url { get; set; }
        public ServiceWeighted Weighted { get; set; }


    }
}
