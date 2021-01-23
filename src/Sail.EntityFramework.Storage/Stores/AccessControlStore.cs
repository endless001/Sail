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
    public class AccessControlStore : IAccessControlStore
    {   
        protected readonly IConfigurationDbContext Context;

        protected readonly ILogger<AccessControlStore> Logger;

        public AccessControlStore(IConfigurationDbContext context, ILogger<AccessControlStore> logger)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Logger = logger;
        }
        
        public async Task<(List<AccessControl>, int)> PageListAccessControlAsync(int pageIndex, int pageSize)
        {
            var totalItems = await Context.AccessControls
                .CountAsync();

            
            var itemsOnPage = await Context.AccessControls
                .OrderBy(c => c.Id)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .Select(a=>a.ToModel())
                .ToListAsync();
            return (itemsOnPage, totalItems);
        }

        public async Task<bool> CreateAccessControlAsync(AccessControl model)
        {
             
            await Context.AccessControls.AddAsync(model.ToEntity());
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAccessControlAsync(int id)
        {
            var entity = new Entities.AccessControl
            {
                Id =id
            };
            Context.Entry(entity).State = EntityState.Deleted;  
            var result=await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<AccessControl> FindAccessControlByIdAsync(int id)
        {
            var entity= await Context.AccessControls.FindAsync(id);
            return entity.ToModel();
        }

        public async Task<bool> UpdateAccessControlAsync(AccessControl model)
        {
            Context.AccessControls.Update(model.ToEntity());
            var  result= await Context.SaveChangesAsync();
            return result > 0;
        }
    }
}
