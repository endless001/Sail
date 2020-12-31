using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sail.EntityFramework.Storage.Entities;


namespace Sail.EntityFramework.Storage.Interfaces
{
    public interface IConfigurationDbContext:IDisposable
    {
        DbSet<Tenant> Tenants { get; set; }
        Task<int> SaveChangesAsync();
        EntityEntry Entry(object entity);
    }
}
