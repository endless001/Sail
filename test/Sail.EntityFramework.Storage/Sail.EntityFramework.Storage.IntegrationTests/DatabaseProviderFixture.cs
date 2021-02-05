﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sail.EntityFramework.Storage.IntegrationTests
{
    public class DatabaseProviderFixture<T> : IDisposable where T : DbContext
    {
        public object StoreOptions;
        public List<DbContextOptions<T>> Options;

        public void Dispose()
        {
            if (Options != null) // null check since fixtures are created even when tests are skipped
            {
                foreach (var option in Options.ToList())
                {
                    using (var context = (T)Activator.CreateInstance(typeof(T), option, StoreOptions))
                    {
                        context.Database.EnsureDeleted();
                    }
                }
            }
        }
    }
}