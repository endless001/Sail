using Sail.Storage.Models;
using Sail.Storage.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.EntityFramework.Storage.Stores
{
    public class ServiceStore : IServiceStore
    {
        public Task<bool> CreateServiceAsync(Service model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Service> FindServiceByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(List<Service>, int)> ServicePageListAsync(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateServiceAsync(Service model)
        {
            throw new NotImplementedException();
        }
    }
}
