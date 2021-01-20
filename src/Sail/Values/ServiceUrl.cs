using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Values
{
    public class ServiceUrl
    {
        public string DownstreamHost { get;  }
        public int DownstreamPort { get;  }
        public string Scheme { get; }
        public ServiceUrl(string downstreamHost,int downstreamPort)
        {
            DownstreamHost = downstreamHost?.Trim('/');
            DownstreamPort = downstreamPort;
        }
        public ServiceUrl(string downstreamHost, int downstreamPort, string scheme)
            : this(downstreamHost, downstreamPort) => Scheme = scheme;
    }
}