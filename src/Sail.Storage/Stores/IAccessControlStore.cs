using Sail.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Storage.Stores
{
    public interface IAccessControlStore
    {
        Task<AccessControl> FindAccessControlByIdAsync(int id);
        Task<bool> CreateAccessControlAsync(AccessControl model);
        Task<bool> UpdateAccessControlAsync(AccessControl model);
        Task<bool> DeleteAccessControlAsync(int id);
        Task<(List<AccessControl>, int)> PageListAccessControlAsync(int pageIndex, int pageSize);
    }
}
