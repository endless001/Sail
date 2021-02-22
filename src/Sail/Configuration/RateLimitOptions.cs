using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Configuration
{
    public class RateLimitOptions
    {
        public RateLimitRule RateLimitRule { get; set; }
        public IEnumerable<string> ClientWhitelist { get; set; }
        public string ClientIdHeader { get; set; }
        public int HttpStatusCode { get; set; }
        public string QuotaExceededMessage { get; set; }
        public string RateLimitCounterPrefix { get; set; }
        public bool EnableRateLimiting { get; set; }
        public bool DisableRateLimitHeaders { get; set; }
    }
}
