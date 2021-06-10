﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sail.Kubernetes.Controller.Dispatching
{
    public class Dispatcher : IDispatcher
    {
        private readonly ILogger<Dispatcher> _logger;
        private readonly object _targetsSync = new object();
        private ImmutableList<IDispatchTarget> _targets = ImmutableList<IDispatchTarget>.Empty;
        private Action<IDispatchTarget> _attached;

        public Dispatcher(ILogger<Dispatcher> logger)
        {
            _logger = logger;
        }


        public void Attach(IDispatchTarget target)
        {

            _logger.LogDebug("Attaching {DispatchTarget}", target?.ToString());
            lock (_targetsSync)
            {
                _targets = _targets.Add(target);
            }
            _attached?.Invoke(target);
        }

        public void Detach(IDispatchTarget target)
        {
            _logger.LogDebug("Detaching {DispatchTarget}", target?.ToString());
            lock (_targetsSync)
            {
                _targets = _targets.Remove(target);
            }
        }

        public void OnAttach(Action<IDispatchTarget> attached)
        {
            _attached = attached;
        }

        public async Task SendAsync(IDispatchTarget specificTarget, byte[] utf8Bytes, CancellationToken cancellationToken)
        {
            if (specificTarget != null)
            {
                await specificTarget.SendAsync(utf8Bytes, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                foreach (var target in _targets)
                {
                    await target.SendAsync(utf8Bytes, cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}
