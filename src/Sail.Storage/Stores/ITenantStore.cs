using Sail.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Stores
{
    public interface ITenantStore
    {
        Task<Tenant> FindTenantByIdAsync(int id);
        Task<bool> CreateTenantAsync(Tenant model);
        Task<bool> UpdateTenantAsync(Tenant model);
        Task<bool> DeleteTenantAsync(int id);
        Task<Tenant> VerificationSecretAsync(string secret);
        Task<(List<Tenant>, int)> PageListTenantAsync(int pageIndex, int pageSize);
    }
}
