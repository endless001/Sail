using Sail.Storage.Models;
using Sail.Storage.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.EntityFramework.Storage.Stores
{
    public class GrpcRuleStore : IGrpcRuleStore
    {
        public Task<bool> CreateGrpcRuleAsync(GrpcRule model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGrpcRuleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GrpcRule> FindGrpcRuleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(List<GrpcRule>, int)> GrpcRulePageListAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGrpcRuleAsync(GrpcRule model)
        {
            throw new NotImplementedException();
        }
    }
}
