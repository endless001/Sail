using System;
using Microsoft.EntityFrameworkCore;
using Sail.EntityFramework.Storage.Interfaces;
using Sail.EntityFramework.Storage.Options;
using Sail.EntityFramework.Storage.Entities;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
