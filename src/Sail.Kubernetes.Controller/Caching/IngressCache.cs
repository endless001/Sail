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
    public class IngressCache : ICache
    { 

        private readonly object _sync = new object();
        private readonly Dictionary<string, NamespaceCache> _namespaceCaches = new Dictionary<string, NamespaceCache>();

        public void GetKeys(List<NamespacedName> keys)
        {
            throw new NotImplementedException();
        }

        public bool TryGetReconcileData(NamespacedName key, out ReconcileData data)
        {
            throw new NotImplementedException();
        }

        public void Update(WatchEventType eventType, V1Ingress ingress)
        {
            if (ingress is null)
            {
                throw new ArgumentNullException(nameof(ingress));
            }
        }

        public ImmutableList<string> Update(WatchEventType eventType, V1Endpoints endpoints)
        {
            throw new NotImplementedException();
        }
    }
}
