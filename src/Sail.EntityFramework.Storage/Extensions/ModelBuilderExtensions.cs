using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sail.EntityFramework.Storage.Options;
using Microsoft.EntityFrameworkCore;
using Sail.EntityFramework.Storage.Entities;

namespace Sail.EntityFramework.Storage.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static EntityTypeBuilder<TEntity> ToTable<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, TableConfiguration configuration)
          where TEntity : class
        {
            return string.IsNullOrWhiteSpace(configuration.Schema) ? entityTypeBuilder.ToTable(configuration.Name) : entityTypeBuilder.ToTable(configuration.Name, configuration.Schema);
        }

        public static void ConfigureTenantContext(this ModelBuilder modelBuilder, ConfigurationStoreOptions storeOptions)
        {
            if (!string.IsNullOrWhiteSpace(storeOptions.DefaultSchema))
            {
                modelBuilder.HasDefaultSchema(storeOptions.DefaultSchema);
            }

      
            modelBuilder.Entity<Tenant>(secret =>
            {
                secret.ToTable(storeOptions.Tenant);
            });
            modelBuilder.Entity<AccessControl>(secret =>
            {
                secret.ToTable(storeOptions.AccessControl);
            });

            modelBuilder.Entity<HttpRule>(secret =>
            {
                secret.ToTable(storeOptions.HttpRule);
            });

            modelBuilder.Entity<TcpRule>(secret =>
            {
                secret.ToTable(storeOptions.TcpRule);
            });

            modelBuilder.Entity<GrpcRule>(secret =>
            {
                secret.ToTable(storeOptions.GrpcRule);
            });

            modelBuilder.Entity<Service>(secret =>
            {
                secret.ToTable(storeOptions.Service);
            });

        }
    }
}
