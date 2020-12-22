using System;
using System.Threading.Tasks;
using Sail.Storage.Models;
using Sail.Storage.Stores;

namespace Sail.EntityFramework.Storage.Stores
{
    public class TcpRuleStore : ITcpRuleStore
    {
        public Task<bool> CreateTcpRuleAsync(TcpRule model)
        {
            throw new NotImplementedException();
        }

        public Task<TcpRule> FindTcpRuleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
