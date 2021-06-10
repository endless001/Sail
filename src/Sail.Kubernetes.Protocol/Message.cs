using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Yarp.ReverseProxy.RuntimeModel;

namespace Sail.Kubernetes.Protocol
{
    public enum MessageType
    {
        Heartbeat,
        Update,
        Remove,
    }

    public struct Message
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public MessageType MessageType { get; set; }
        public string Key { get; set; }
        public List<RouteConfig> Routes { get; set; }
        public List<ClusterConfig> Cluster { get; set; }
    }
}
