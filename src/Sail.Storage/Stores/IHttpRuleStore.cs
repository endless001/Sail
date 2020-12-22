using Sail.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Stores
{
    public interface IHttpRuleStore
    {
        Task<HttpRule> FindHttpRuleByIdAsync(int id);
        Task<bool> CreateHttpRuleAsync(HttpRule model);
        Task<bool> UpdateHttpRuleAsync(HttpRule model);
        Task<bool> DeleteHttpRuleAsync(int id);
        Task<(List<HttpRule>, int)> HttpRulePageListAsync(int pageIndex, int pageSize);
    }
}
