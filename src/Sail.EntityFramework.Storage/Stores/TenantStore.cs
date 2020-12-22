using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sail.EntityFramework.Storage.Interfaces;
using Sail.Storage.Models;
using Sail.Storage.Stores;


namespace Sail.EntityFramework.Storage.Stores
{
    public class TenantStore : ITenantStore
    {

        protected readonly IConfigurationDbContext Context;

        protected readonly ILogger<TenantStore> Logger;

        public TenantStore(IConfigurationDbContext context, ILogger<TenantStore> logger)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Logger = logger;
        }

        public Task<bool> CreateTenantAsync(Tenant model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTenantAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tenant> FindTenantByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(List<Tenant>, int)> TenantPageListAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTenantAsync(Tenant model)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITenantStore.CreateTenantAsync(Tenant model)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITenantStore.DeleteTenantAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Tenant> ITenantStore.FindTenantByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<(List<Tenant>, int)> ITenantStore.TenantPageListAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITenantStore.UpdateTenantAsync(Tenant model)
        {
            throw new NotImplementedException();
        }
    }
}
