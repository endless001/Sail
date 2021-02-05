using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sail.EntityFramework.DbContexts;
using Sail.EntityFramework.Storage.Entities;
using Sail.EntityFramework.Storage.Options;
using Xunit;

namespace Sail.EntityFramework.Storage.IntegrationTests.DbContexts
{
    public class ConfigurationDbContextTests:IntegrationTest<ConfigurationDbContextTests,ConfigurationDbContext, ConfigurationStoreOptions>
    {
        public ConfigurationDbContextTests(DatabaseProviderFixture<ConfigurationDbContext> fixture) : base(fixture)
        {
            foreach (var options in  TestDatabaseProviders.SelectMany(x => x.Select(y => (DbContextOptions<ConfigurationDbContext>)y)).ToList())
            {
                using (var context = new ConfigurationDbContext(options, StoreOptions))
                    context.Database.EnsureCreated();
            }
        }
        
        [Theory, MemberData(nameof(TestDatabaseProviders))]
        public void CanAddAndDeleteTeantScopes(DbContextOptions<ConfigurationDbContext> options)
        {
            using (var db = new ConfigurationDbContext(options, StoreOptions))
            {
                db.Tenants.Add(new Tenant
                {
                   AppId = 1,
                });

                db.SaveChanges();
            }
         
        }
    }
}