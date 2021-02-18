using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sail.EntityFramework.DbContexts;
using Sail.EntityFramework.Storage.Options;
using Serilog;

namespace Sail.Administration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();
            Log.Logger = CreateSerilogLogger(configuration);
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .UseSerilog()
              .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)=>
            new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
    public class ConfigurationDbContextFactory : IDesignTimeDbContextFactory<ConfigurationDbContext>
    {
        public ConfigurationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddEnvironmentVariables();

            var optionsBuilder = new DbContextOptionsBuilder<ConfigurationDbContext>(); 
            optionsBuilder.UseSqlServer("Data Source=blog.db", dbOpts => dbOpts.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
            var storeOptions = new ConfigurationStoreOptions();
            return new ConfigurationDbContext(optionsBuilder.Options, storeOptions);
        }
    }
}
