using Sail.Kubernetes.Controller.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sail.Kubernetes.Controller.Services
{
    public struct ReconcileData
    {
        public ReconcileData(IngressData ingress, List<Endpoints> endpoints)
        {
            Ingress = ingress;
            EndpointsList = endpoints;
        }

        public IngressData Ingress { get; set; }
        public List<Endpoints> EndpointsList { get; }
    }
}
