using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.RateLimit
{
    public class RateLimitCore
    {
        private readonly IRateLimitCounterHandler _counterHandler;
        private static readonly object _processLocker = new object();
       
        public RateLimitCore(IRateLimitCounterHandler counterHandler)
        {
            _counterHandler = counterHandler;
        }


    }
}