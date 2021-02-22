using Sail.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Extensions
{
    public static class HttpItemsExtensions
    {
        public static DownstreamRoute DownstreamRoute(this IDictionary<object, object> input)
        {
            return input.Get<DownstreamRoute>("DownstreamRoute");
        }
        private static T Get<T>(this IDictionary<object, object> input, string key)
        {
            if (input.TryGetValue(key, out var value))
            {
                return (T)value;
            }
            return default(T);
        }
    }
}
