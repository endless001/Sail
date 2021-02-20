using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.RateLimit
{
   public class RateLimitCounter
    {
        public DateTime Timestamp { get; set; }

        public long TotalRequests { get; set; }
    }
}
