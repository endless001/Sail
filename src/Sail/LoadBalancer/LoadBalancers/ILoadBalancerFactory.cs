using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.LoadBalancer.LoadBalancers
{
    public interface ILoadBalancerFactory
    {
        ILoadBalancer Get();
    }
}
