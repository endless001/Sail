using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sail.RateLimit
{
    public class RedisLimitCounterHanlder : IRateLimitCounterHandler
    {

        private readonly ConnectionMultiplexer _redis;
        private readonly ILogger<RedisLimitCounterHanlder> _logger;
        private readonly IDatabase _database;


        public RedisLimitCounterHanlder(ILogger<RedisLimitCounterHanlder> logger, ConnectionMultiplexer redis)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _redis = redis;
            _database = redis.GetDatabase();

        }

        public bool Exists(string id)
        {
            return !string.IsNullOrEmpty(_database.StringGet(id));
        }

        public RateLimitCounter Get(string id)
        {
            var value = _database.StringGet(id);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<RateLimitCounter>(value);
            }
            return null;
        }

        public void Remove(string id)
        {
            _database.KeyDelete(id);
        }

        public void Set(string id, RateLimitCounter counter, TimeSpan expirationTime)
        {
            _database.StringSet(id, JsonSerializer.Serialize(counter), expirationTime);
        }
    }
}
