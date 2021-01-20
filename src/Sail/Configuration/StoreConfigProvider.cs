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
        
        public  StoreConfigProvider(ILogger<StoreConfigProvider> logger,ConnectionMultiplexer redis)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redis = redis;
            _database = redis.GetDatabase();
        }
        

        public IProxyConfig GetConfig()
        {
            return  UpdateSnapshot();
        }

        private StoreConfig UpdateSnapshot()
        {
            StoreConfig snapshot = new StoreConfig();
            var clusters = _database.ListRange("clusters");
            var routes = _database.ListRange("routes");
            foreach (var cluster in clusters)
            {
                snapshot.Clusters.Add(CreateCluster());
            }

            foreach (var route in routes)
            {
                snapshot.Routes.Add(CreateRoute());
            }

            return snapshot;
        }

        private Cluster CreateCluster()
        {
            var cluster = new Cluster
            {
                
            };
            return cluster;
        }
        
        private ProxyRoute CreateRoute()
        {
            var route = new ProxyRoute
            {
                
            };
            return route;
        }

    }
}