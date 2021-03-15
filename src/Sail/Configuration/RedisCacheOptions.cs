using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Sail.Configuration
{
    public class RedisCacheOptions:IOptions<RedisCacheOptions>
    {
        public string Configuration { get; set; }

        /// <summary>
        /// The configuration used to connect to Redis.
        /// This is preferred over Configuration.
        /// </summary>
        public ConfigurationOptions ConfigurationOptions { get; set; }

        /// <summary>
        /// The Redis instance name.
        /// </summary>
        public string InstanceName { get; set; }

        RedisCacheOptions IOptions<RedisCacheOptions>.Value
        {
            get { return this; }
        }
    }
}