using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.RateLimit
{
    public class RedisRateLimitCounterHanlder : IRateLimitCounterHandler
    {
       
        public bool Exists(string id)
        {
            throw new NotImplementedException();
        }

        public RateLimitCounter Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Set(string id, RateLimitCounter counter, TimeSpan expirationTime)
        {
            throw new NotImplementedException();
        }
    }
}
