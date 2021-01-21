using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ReverseProxy.Abstractions;
using Microsoft.ReverseProxy.Service;
using StackExchange.Redis;

namespace Sail.Configuration
{
    public class StoreConfigProvider : IProxyConfigProvider
    {
        
        private readonly ConnectionMultiplexer _redis;
        private readonly ILogger<StoreConfigProvider> _logger;
        private readonly IDatabase _database;
        private volatile  StoreConfig _snapshot;
        
        public  StoreConfigProvider(ILogger<StoreConfigProvider> logger,ConnectionMultiplexer redis)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redis = redis;
            _database = redis.GetDatabase();
            
        }
        

        public IProxyConfig GetConfig()
        {
            if (_snapshot==null)
            {
                UpdateSnapshot();
            }
            return  _snapshot;
        }

        private void UpdateSnapshot()
        {
            _snapshot.Clusters.Add(CreateCluster());
            _snapshot.Routes.Add(CreateRoute());
        }

        private Cluster CreateCluster()
        {
            var cluster = new Cluster()
            {
                Id = "cluster1",
                Destinations =
                {
                    {"destination1", new Destination() {Address = "https://example.com"}}
                }
            };
            return cluster;
        }
        
        private ProxyRoute CreateRoute()
        {
            var route = new ProxyRoute()
            {
                RouteId = "route1",
                ClusterId = "cluster1",
                Match =
                {
                    Path = "{**catch-all}"
                }
            };
            return route;
        }

    }
}