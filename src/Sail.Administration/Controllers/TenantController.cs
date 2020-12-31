using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sail.Storage.Models;
using Sail.Storage.Stores;

namespace Sail.Administration.Controllers
{
    public class TenantController : Controller
    {
        private readonly ILogger<TenantController> _logger;
        private readonly ITenantStore _tenantStore;
        public TenantController(ILogger<TenantController> logger, ITenantStore tenantStore)
        {
            _logger = logger;
            _tenantStore = tenantStore;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTenant()
        {
            var model = new Tenant();
            await _tenantStore.CreateTenantAsync(model);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> FindTenantById(int id)
        {
            var result = await _tenantStore.FindTenantByIdAsync(id);
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteTenant(int id)
        {
            await _tenantStore.DeleteTenantAsync(id);
            return Ok();
        }
        
    }
}
