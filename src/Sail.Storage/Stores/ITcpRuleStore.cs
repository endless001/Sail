using Sail.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Stores
{
    public interface ITcpRuleStore
    {
        Task<TcpRule> FindTcpRuleByIdAsync(int id);
        Task<bool> CreateTcpRuleAsync(TcpRule model);


    }
}
