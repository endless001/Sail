using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.RateLimit
{
    public class ClientRateLimitProcessor
    {
        private readonly IRateLimitCounterHandler _counterHandler;
        private readonly RateLimitCore _core;

        public ClientRateLimitProcessor(IRateLimitCounterHandler  counterHandler)
        {
            _counterHandler = counterHandler;
            _core = new RateLimitCore(_counterHandler);
        }

        
    }
}
