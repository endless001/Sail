using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.RateLimit
{
    public interface IRateLimitCounterHandler
    {
        bool Exists(string id);

        RateLimitCounter Get(string id);

        void Remove(string id);

        void Set(string id, RateLimitCounter counter, TimeSpan expirationTime);
    }
}