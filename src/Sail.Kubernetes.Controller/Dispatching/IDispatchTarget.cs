﻿using System.Threading;
using System.Threading.Tasks;

namespace Sail.Kubernetes.Controller.Dispatching
{
    public interface IDispatchTarget
    {
        public Task SendAsync(byte[] utf8Bytes, CancellationToken cancellationToken);
    }
}
