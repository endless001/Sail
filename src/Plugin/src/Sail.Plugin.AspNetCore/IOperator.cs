using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sail.Pulgin.AspNetCore
{
    public interface IOperator
    {
        Task Run(HttpContext context);
    }
}
