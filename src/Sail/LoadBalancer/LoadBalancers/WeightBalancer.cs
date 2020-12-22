using Sail.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.LoadBalancer.LoadBalancers
{
    public class WeightBalancer : ILoadBalancer
    {
        private readonly Func<Task<List<Service>>> _services;

        public WeightBalancer(Func<Task<List<Service>>> services)
        {
            _services = services;
        }


        public async Task<ServiceUrl> Get()
        {
            var total = 0;
            var services = await _services();
            var best = new Service();

            foreach (var service in services)
            {

                total += service.Weighted.EffectiveWeight;
                service.Weighted.CurrnetWeight += service.Weighted.EffectiveWeight;

                if (service.Weighted.EffectiveWeight < service.Weighted.Weight)
                {
                    service.Weighted.EffectiveWeight++;
                }
                if (best == null || service.Weighted.CurrnetWeight > best.Weighted.CurrnetWeight)
                {
                    best = service;
                }
            }
            best.Weighted.CurrnetWeight -= total;
            return best.Url;
        }
    }
}
