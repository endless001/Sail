using Sail.Storage.Models;
using Sail.Storage.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sail.EntityFramework.Storage.Interfaces;

namespace Sail.EntityFramework.Storage.Stores
{
    public class HttpRuleStore : IHttpRuleStore
    {
        protected readonly IConfigurationDbContext Context;

        protected readonly ILogger<HttpRuleStore> Logger;
        
        public Task<bool> CreateHttpRuleAsync(HttpRule model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteHttpRuleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpRule> FindHttpRuleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(List<HttpRule>, int)> HttpRulePageListAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHttpRuleAsync(HttpRule model)
        {
            throw new NotImplementedException();
        }
    }
}
