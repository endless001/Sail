using System;
using Microsoft.EntityFrameworkCore;
using Sail.EntityFramework.Storage.Entities;


namespace Sail.EntityFramework.Storage.Interfaces
{
    public interface IConfigurationDbContext:IDisposable
    {
        DbSet<Tenant> Tenants { get; set; }
    }
}
