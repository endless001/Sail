using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.RateLimit
{
    public class ClientRequestIdentity
    {
        public string ClientId { get; set; }
        public string Path { get; set; }
        public string HttpVerb { get; set; }

    }
}
