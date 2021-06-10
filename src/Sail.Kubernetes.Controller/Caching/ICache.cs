using k8s;
using k8s.Models;
using Microsoft.Kubernetes;
using Sail.Kubernetes.Controller.Services;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Sail.Kubernetes.Controller.Caching
{
    public interface ICache
    {
        void Update(WatchEventType eventType, V1Ingress ingress);
        ImmutableList<string> Update(WatchEventType eventType, V1Endpoints endpoints);
        bool TryGetReconcileData(NamespacedName key, out ReconcileData data);
        void GetKeys(List<NamespacedName> keys);
    }
}
