using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.LoadBalancer.Middleware
{
    public class LoadBalancingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoadBalancingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {


        }
    }
  
}
