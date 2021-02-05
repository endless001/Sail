using Microsoft.EntityFrameworkCore;

namespace Sail.EntityFramework.Storage.IntegrationTests
{
    public class DatabaseProviderBuilder
    {
        public static DbContextOptions<T> BuildInMemory<T>(string name) where T : DbContext
        {
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseInMemoryDatabase(name);
            return builder.Options;
        }
        
        public static DbContextOptions<T> BuildSqlite<T>(string name) where T : DbContext
        {
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlite($"Filename=./Test.IdentityServer4.EntityFramework-3.1.0.{name}.db");
            return builder.Options;
        }
        
        public static DbContextOptions<T> BuildLocalSqlServer<T>(string name) where T : DbContext
        {
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlServer(
                $@"Data Source=(LocalDb)\MSSQLLocalDB;database=Test.IdentityServer4.EntityFramework-3.1.0.{name};trusted_connection=yes;");
            return builder.Options;
        }
    }
}