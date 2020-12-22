using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.LoadBalancer.LoadBalancers
{
    public class LoadBalancerFactory : ILoadBalancerFactory
    {
        public ILoadBalancer Get()
        {
            throw new NotImplementedException();
        }
    }
}
