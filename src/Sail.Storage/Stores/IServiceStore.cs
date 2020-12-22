using Sail.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Stores
{
    public interface IServiceStore
    {
        Task<Service> FindServiceByIdAsync(int id);
        Task<bool> CreateServiceAsync(Service model);
        Task<bool> UpdateServiceAsync(Service model);
        Task<bool> DeleteServiceAsync(int id);
        Task<(List<Service>, int)> ServicePageListAsync(int pageIndex, int pageSize);

    }
}
