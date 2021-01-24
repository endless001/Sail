using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sail.Storage.Stores;
using ILogger = Serilog.ILogger;

namespace Sail.Administration.Controllers
{
    public class AccessControlController:Controller
    {
        private readonly ILogger<AccessControlController> _logger;
        private readonly IAccessControlStore _accessControlStore;

        public AccessControlController(ILogger<AccessControlController> logger, IAccessControlStore accessControlStore)
        {
            _logger = logger;
            _accessControlStore = accessControlStore;
        }
        
        
    }
}