using k8s.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sail.Kubernetes.Controller.Caching
{
    public struct Endpoints
    {
        public Endpoints(V1Endpoints endpoints)
        {
            if (endpoints is null)
            {
                throw new ArgumentNullException(nameof(endpoints));
            }

            Name = endpoints.Name();
            Subsets = endpoints.Subsets;
        }

        public string Name { get; set; }
        public IList<V1EndpointSubset> Subsets { get; }
    }
}
