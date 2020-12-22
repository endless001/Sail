using Sail.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Stores
{
    public interface IGrpcRuleStore
    {
        Task<GrpcRule> FindGrpcRuleByIdAsync(int id);
        Task<bool> CreateGrpcRuleAsync(GrpcRule model);
        Task<bool> UpdateGrpcRuleAsync(GrpcRule model);
        Task<bool> DeleteGrpcRuleAsync(int id);
        Task<(List<GrpcRule>, int)> GrpcRulePageListAsync(int pageIndex, int pageSize);
    }
}
