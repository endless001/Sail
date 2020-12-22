using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Sail.Values;

namespace Sail.LoadBalancer.LoadBalancers
{
   public interface ILoadBalancer
    {
        Task<ServiceUrl> Get();

    }
}
