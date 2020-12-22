using Sail.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.LoadBalancer.LoadBalancers
{
    public class RandomBalancer : ILoadBalancer
    {
        private readonly Func<Task<List<Service>>> _services;

        public RandomBalancer(Func<Task<List<Service>>> services)
        {
            _services = services;
        }
        public async Task<ServiceUrl> Get()
        {
   
            var services= await _services();
            var index = new Random().Next(services.Count);
            var service = services[index];
            return service.Url;

        }
    }
}
