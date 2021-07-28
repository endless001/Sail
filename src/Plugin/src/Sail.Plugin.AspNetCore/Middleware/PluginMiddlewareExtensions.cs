using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Pulgin.AspNetCore.Middleware
{
    public static class PluginMiddlewareExtensions
    {
        public static IApplicationBuilder UsePlugin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PluginMiddleware>();
        }
    }
}
