using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.RateLimit
{
    public class RateLimitHeaders
    {
        public HttpContext Context { get; set; }
        public string Limit { get; private set; }
        public string Remaining { get; private set; }
        public string Reset { get; private set; }
    }
}
