using Microsoft.EntityFrameworkCore;

namespace Sail.EntityFramework.DbContexts
{
    public class TestContext:DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }
    }
}