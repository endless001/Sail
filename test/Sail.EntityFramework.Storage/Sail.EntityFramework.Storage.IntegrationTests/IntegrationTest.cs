using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Sail.EntityFramework.Storage.IntegrationTests
{
    public class IntegrationTest<TClass,TDbContext,TStoreOption>: IClassFixture<DatabaseProviderFixture<TDbContext>> 
        where TDbContext : DbContext
    {

        static IntegrationTest()
        {
            var config = new ConfigurationBuilder();

        }
        
    }
}