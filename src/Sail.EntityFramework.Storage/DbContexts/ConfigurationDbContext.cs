using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sail.EntityFramework.Storage.Interfaces;
using Sail.EntityFramework.Storage.Options;
using Sail.EntityFramework.Storage.Entities;
using Sail.EntityFramework.Storage.Extensions;

namespace Sail.EntityFramework.Storage.DbContexts
{
    public class ConfigurationDbContext :ConfigurationDbContext<ConfigurationDbContext>
    {
        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options, ConfigurationStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }

    public class ConfigurationDbContext<TContext> : DbContext,IConfigurationDbContext
        where TContext:DbContext,IConfigurationDbContext
    {
        private readonly ConfigurationStoreOptions _storeOptions;

        public ConfigurationDbContext(DbContextOptions<TContext> options, ConfigurationStoreOptions storeOptions)
            :base(options)
        {
            _storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));
        }

        public DbSet<AccessControl> AccessControls { get; set; }
        public DbSet<GrpcRule> GrpcRules { get; set; }
        public DbSet<HttpRule> HttpRules { get; set; }
        
        public DbSet<Service> Services { get; set; }
        public DbSet<TcpRule> TcpRules { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public  EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureTenantContext(_storeOptions);
            base.OnModelCreating(modelBuilder);
        }
    }
}
