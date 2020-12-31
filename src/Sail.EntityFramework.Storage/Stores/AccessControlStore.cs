using Sail.Storage.Models;
using Sail.Storage.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sail.EntityFramework.Storage.Interfaces;

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
        
        public Task<(List<AccessControl>, int)> AccessControlPageListAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAccessControlAsync(AccessControl model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccessControlAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccessControl> FindAccessControlByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAccessControlAsync(AccessControl model)
        {
            throw new NotImplementedException();
        }
    }
}
