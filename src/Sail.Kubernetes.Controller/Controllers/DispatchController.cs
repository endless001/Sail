using Microsoft.AspNetCore.Mvc;
using Sail.Kubernetes.Controller.Dispatching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sail.Kubernetes.Controller.Controllers
{
    [Route("api/dispatch")]
    [ApiController]
    public class DispatchController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public DispatchController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("/api/dispatch")]
        public Task<IActionResult> WatchAsync()
        {
            return new Task<IActionResult>(() => new DispatchActionResult(_dispatcher, HttpContext.RequestAborted));
        }

    }
}
