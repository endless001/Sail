using Microsoft.AspNetCore.Http;
using Sail.Pulgin.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPlugin
{
    public class ThumbnailOperator : IOperator
    {
        public async Task Run(HttpContext context)
        {
            await context.Response.WriteAsync("Thumbnail");
        }
    }
}
