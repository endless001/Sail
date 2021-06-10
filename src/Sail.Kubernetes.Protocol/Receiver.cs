using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Kubernetes.Controller.Hosting;
using Microsoft.Kubernetes.Controller.Rate;

namespace Sail.Kubernetes.Protocol
{
    public class Receiver : BackgroundHostedService
    {

        private readonly ReceiverOptions _options;
        private readonly Limiter _limiter;
        private readonly IUpdateConfig _proxyConfigProvider;

        public Receiver(
            IOptions<ReceiverOptions> options,
            ILogger<Receiver> logger,
            IHostApplicationLifetime hostApplicationLifetime,
            IUpdateConfig proxyConfigProvider) : base(hostApplicationLifetime, logger)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _options = options.Value;

            // two requests per second after third failure
            _limiter = new Limiter(new Limit(2), 3);
            _proxyConfigProvider = proxyConfigProvider;
        }

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            using var client = new HttpClient();

            Logger.LogInformation("Connecting with {ControllerUrl}", _options.ControllerUrl.ToString());

            throw new Exception();

        }
    }
}
