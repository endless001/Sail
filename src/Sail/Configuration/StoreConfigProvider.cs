using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using StackExchange.Redis;
using Yarp.ReverseProxy.Abstractions;
using Yarp.ReverseProxy.Abstractions.ClusterDiscovery.Contract;
using Yarp.ReverseProxy.Service;

namespace Sail.Configuration
{
    public class StoreConfigProvider : IProxyConfigProvider
    {
        
        private readonly ConnectionMultiplexer _redis;
        private readonly ILogger<StoreConfigProvider> _logger;
        private readonly IDatabase _database;
        private volatile StoreConfig _snapshot;
        private CancellationTokenSource _changeToken;

        public StoreConfigProvider(ILogger<StoreConfigProvider> logger, ConnectionMultiplexer redis)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redis = redis;
            _database = redis.GetDatabase();

        }

        public IProxyConfig GetConfig()
        {
            if (_snapshot == null)
            {
                UpdateSnapshot();
            }
            return  _snapshot;
        }

        private void UpdateSnapshot()
        {
            StoreConfig snapshot = null;
            try
            {
                snapshot = new StoreConfig();
                var clusters = _database.HashGetAll("clusters");
                var routes = _database.HashGetAll("routes");
                foreach (var cluster in clusters)
                {
                    snapshot.Clusters.Add(CreateCluster());
                }
                
                foreach (var route in routes)
                {
                    snapshot.Routes.Add(CreateRoute());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
       
            var oldToken = _changeToken;
            _changeToken = new CancellationTokenSource();
            snapshot.ChangeToken = new CancellationChangeToken(_changeToken.Token);
            _snapshot = snapshot;
            
            try
            {
                oldToken?.Cancel(throwOnFirstException: false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private Cluster CreateCluster()
        {
            var cluster = new Cluster()
            {
                Id = "cluster1",
                LoadBalancingPolicy = LoadBalancingPolicies.Random,
                Metadata = { },
                HttpRequest = { },
                Destinations =
                {
          
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
