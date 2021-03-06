﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sail.Storage.Models;
using Sail.Storage.Stores;

namespace Sail.Administration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IServiceStore _serviceStore;

        public ServiceController(ILogger<ServiceController> logger,IServiceStore serviceStore)
        {
            _logger = logger;
            _serviceStore = serviceStore;
        }
        
        [HttpGet]
        public async Task<IActionResult> PageListService(int pageIndex,int pageSize)
        {
            
            var result = await _serviceStore.PageListServiceAsync(pageIndex, pageSize);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody]Service service)
        {
            var result = await _serviceStore.CreateServiceAsync(service);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService([FromQuery] int id,[FromBody] Service service)
        {
            var result = await _serviceStore.UpdateServiceAsync(service);
            return Ok(result);
        }
 
        [HttpGet("{id}")]
        public async Task<IActionResult> FindServiceById(int id)
        {
            var result = await _serviceStore.FindServiceByIdAsync(id);
            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _serviceStore.DeleteServiceAsync(id);
            return Ok(result);
        }  
    }
}