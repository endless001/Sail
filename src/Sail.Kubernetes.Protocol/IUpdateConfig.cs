using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yarp.ReverseProxy.RuntimeModel;

namespace Sail.Kubernetes.Protocol
{
    public interface IUpdateConfig
    {
        void Update(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters);
    }
}
