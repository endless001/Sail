using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Yarp.ReverseProxy.Abstractions;
using Yarp.ReverseProxy.Service;

namespace Sail.Configuration
{
    public class StoreConfig : IProxyConfig
    {

        public List<ProxyRoute> Routes { get; } = new List<ProxyRoute>();
        public List<Cluster> Clusters { get; } = new List<Cluster>();
        
        IReadOnlyList<ProxyRoute> IProxyConfig.Routes => Routes;

        IReadOnlyList<Cluster> IProxyConfig.Clusters => Clusters;
        
        public IChangeToken ChangeToken { get; internal set; }

    }
}