using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sail.EntityFramework.Storage.Options;

namespace Sail.EntityFramework.Storage.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static EntityTypeBuilder<TEntity> ToTable<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder, TableConfiguration configuration)
          where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
