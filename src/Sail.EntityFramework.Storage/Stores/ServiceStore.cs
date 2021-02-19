using Sail.Storage.Models;
using Sail.Storage.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sail.EntityFramework.Storage.Interfaces;
using Sail.EntityFramework.Storage.Mappers;
namespace Sail.EntityFramework.Storage.Stores
{
    public class ServiceStore : IServiceStore
    {
        
        protected readonly IConfigurationDbContext Context;

        protected readonly ILogger<ServiceStore> Logger;

        public ServiceStore(IConfigurationDbContext context, ILogger<ServiceStore> logger)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Logger = logger;
        }

        
        public async Task<bool> CreateServiceAsync(Service model)
        {
            await Context.Services.AddAsync(model.ToEntity());
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            var entity = new Entities.Service
            {
                Id = id
            };
            Context.Entry(entity).State = EntityState.Deleted;
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Service> FindServiceByIdAsync(int id)
        {
            var entity = await Context.Services.FindAsync(id);
            return entity.ToModel();
        }

        public async Task<(List<Service>, int)> PageListServiceAsync(int pageIndex, int pageSize)
        {
            var totalItems = await Context.Services
                .CountAsync();

            
            var itemsOnPage = await Context.Services
                .OrderBy(c => c.CreateTime)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .Select(a=>a.ToModel())
                .ToListAsync();
            return (itemsOnPage, totalItems);
        }

        public async Task<bool> UpdateServiceAsync(Service model)
        {
            Context.Services.Update(model.ToEntity());
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }
    }
}
