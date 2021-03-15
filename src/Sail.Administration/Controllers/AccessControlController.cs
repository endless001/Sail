using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sail.Storage.Models;
using Sail.Storage.Stores;

namespace Sail.Administration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessControlController: ControllerBase
    {
        private readonly ILogger<AccessControlController> _logger;
        private readonly IAccessControlStore _accessControlStore;

        public AccessControlController(ILogger<AccessControlController> logger, IAccessControlStore accessControlStore)
        {
            _logger = logger;
            _accessControlStore = accessControlStore;
        }
        
        [HttpGet]
        public async Task<IActionResult> PageListAccessControl(int pageIndex,int pageSize)
        {
            var result = await _accessControlStore.PageListAccessControlAsync(pageIndex, pageSize);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAccessControl([FromBody]AccessControl  accessControl)
        {
            var result = await _accessControlStore.CreateAccessControlAsync(accessControl);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTenant([FromBody] AccessControl accessControl)
        {
            var result = await _accessControlStore.UpdateAccessControlAsync(accessControl);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindAccessControlById(int id)
        {
            var result = await _accessControlStore.FindAccessControlByIdAsync(id);
            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteAccessControl(int id)
        {
            var result = await _accessControlStore.DeleteAccessControlAsync(id);
            return Ok(result);
        }
    }
}