using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Pulgin.AspNetCore.Middleware
{
    public class PluginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IEnumerable<IOperator> _operators;

        public PluginMiddleware(RequestDelegate next, IEnumerable<IOperator> operators)
        {
            _next = next;
            _operators = operators;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            foreach (var @operator in _operators)
            {
                await @operator.Run(context);
            }
        }
    }
}
