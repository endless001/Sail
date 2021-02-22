using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Configuration
{
    public class RateLimitRule
    {
        public int Period { get; set; }
        public double PeriodTimespan { get; set; }
        public long Limit { get; set; }
    }
}
