using Microsoft.AspNetCore.Http;
using Sail.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.LoadBalancer.LoadBalancers
{ 
    public class RoundBalancer : ILoadBalancer
    {
        private readonly Func<Task<List<Service>>> _services;

        private int _currentIndex;

        public RoundBalancer(Func<Task<List<Service>>> services)
        {
            _services = services;
        }

        public async Task<ServiceUrl> Get()
        {
            var services = await _services();

            if (_currentIndex >= services.Count)
            {
                _currentIndex = 0;
            }
            var next = services[_currentIndex];
            _currentIndex++;

            return next.Url;
        }
    }
}
