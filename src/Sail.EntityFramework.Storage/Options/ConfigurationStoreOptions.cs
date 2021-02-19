using System;
using Microsoft.EntityFrameworkCore;

namespace Sail.EntityFramework.Storage.Options
{
    public class ConfigurationStoreOptions
    {
        public Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }

        public Action<IServiceProvider, DbContextOptionsBuilder> ResolveDbContextOptions { get; set; }

        public string DefaultSchema { get; set; } = null;

        public TableConfiguration Tenant { get; set; } = new TableConfiguration("tenant");

        public TableConfiguration AccessControl { get; set; } = new TableConfiguration("access_control");

        public TableConfiguration GrpcRule { get; set; } = new TableConfiguration("grpc_rule");

        public TableConfiguration HttpRule { get; set; } = new TableConfiguration("http_rule");

        public TableConfiguration Service { get; set; } = new TableConfiguration("service");

        public TableConfiguration TcpRule { get; set; } = new TableConfiguration("tcp_rule");
    }
}
