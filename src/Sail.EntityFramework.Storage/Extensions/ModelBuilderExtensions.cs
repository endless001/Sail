using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sail.EntityFramework.Storage.Options;
using Microsoft.EntityFrameworkCore;


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
            if (!string.IsNullOrWhiteSpace(storeOptions.DefaultSchema)) modelBuilder.HasDefaultSchema(storeOptions.DefaultSchema);

           
        }
    }
}
