﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Sail.Storage.Models;
using Sail.Storage.Stores;

namespace Sail.Administration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ILogger<TenantController> _logger;
        private readonly ITenantStore _tenantStore;
        public TenantController(ILogger<TenantController> logger, ITenantStore tenantStore)
        {
            _logger = logger;
            _tenantStore = tenantStore;
        }
        
        [HttpGet]
        public async Task<IActionResult> PageTenant(int pageIndex,int pageSize)
        {
            var result = await _tenantStore.PageListTenantAsync(pageIndex, pageSize);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTenant([FromBody] Tenant tenant)
        {
            var result = await _tenantStore.CreateTenantAsync(tenant);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTenant([FromBody] Tenant tenant)
        {
            var result = await _tenantStore.UpdateTenantAsync(tenant);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindTenantById(int id)
        {
            var result = await _tenantStore.FindTenantByIdAsync(id);
            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteTenant(int id)
        {
            var result = await _tenantStore.DeleteTenantAsync(id);
            return Ok(result);
        }
        
    }
}
