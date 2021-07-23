using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Kubernetes.Controller.Hosting;
using Microsoft.Kubernetes.Controller.Rate;

namespace Sail.Kubernetes.Protocol
{
    public class Receiver:BackgroundHostedService
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

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            using var client = new HttpClient();

            while (!cancellationToken.IsCancellationRequested)
            {
                await _limiter.WaitAsync(cancellationToken).ConfigureAwait(false);

                Logger.LogInformation($"Connecting with { _options.ControllerUrl.ToString()}");

                try
                {
                    using var stream = await client.GetStreamAsync(_options.ControllerUrl, cancellationToken).ConfigureAwait(false);
                    using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
                    using var cancellation = cancellationToken.Register(stream.Close);
                    while (true)
                    {
                        var json = await reader.ReadLineAsync().ConfigureAwait(false);
                        if (string.IsNullOrEmpty(json))
                        {
                            break;
                        }

                        var message = JsonSerializer.Deserialize<Message>(json);
                        Logger.LogInformation($"Received {message.MessageType} for { message.Key}");

                        Logger.LogInformation(json);
                        Logger.LogInformation(message.MessageType.ToString());

                        if (message.MessageType == MessageType.Update)
                        {
                            _proxyConfigProvider.Update(message.Routes, message.Cluster);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogInformation($"Stream ended: { ex.Message}");
                }
            }           
        }
    }
}
