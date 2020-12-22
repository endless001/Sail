using Sail.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.LoadBalancer.LoadBalancers
{
    public class HashBalancer :ILoadBalancer
    {
        public Task<ServiceUrl> Get()
        {
            throw new NotImplementedException();
        }
    }
}
