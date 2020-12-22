using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.LoadBalancer.Middleware
{
    public static class LoadBalancingMiddlewareExtensions
    {
        public  static IApplicationBuilder UseLoadBalancingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoadBalancingMiddleware>();
        }

    }
}
