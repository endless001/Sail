using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sail.Plugin.Abstractions;

namespace Sail.Plugin.AspNetCore
{
    public class PluginInitializer : IHostedService
    {
        private readonly IEnumerable<IPlugin> _plugins;
        private readonly ILogger<PluginInitializer> _logger;

        public PluginInitializer(IEnumerable<IPlugin> plugins, ILogger<PluginInitializer> logger)
        {
            _plugins = plugins;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                foreach (var plugin in _plugins)
                {
                    await plugin.Initialize();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
