using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sail.EntityFramework.Storage.Interfaces;
using Sail.EntityFramework.Storage.Mappers;
using Sail.Storage.Models;
using Sail.Storage.Stores;
using System.Linq;
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

        public async Task<bool> CreateTenantAsync(Tenant model)
        {
            await Context.Tenants.AddAsync(model.ToEntity());
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteTenantAsync(int id)
        {
            var entity = new Entities.Tenant
            {
                Id = id
            };
            Context.Entry(entity).State = EntityState.Deleted;
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Tenant> FindTenantByIdAsync(int id)
        {
            var entity = await Context.Tenants.FindAsync(id);
            return entity.ToModel();
        }

        public async Task<(List<Tenant>, int)> PageListTenantAsync(int pageIndex, int pageSize)
        {

            var totalItems = await Context.Tenants
                .CountAsync();

            
            var itemsOnPage = await Context.Tenants
                .OrderBy(c => c.CreateTime)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .Select(a=>a.ToModel())
                .ToListAsync();
            return (itemsOnPage, totalItems);
        }

        public async Task<bool> UpdateTenantAsync(Tenant model)
        {

            Context.Tenants.Update(model.ToEntity());
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Tenant> VerificationSecretAsync(string secret)
        {
            var entity = await Context.Tenants.FirstOrDefaultAsync(t => t.Secret == secret);
            return entity.ToModel();
        }
    }
}
