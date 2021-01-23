using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sail.Storage.Models;
using Sail.Storage.Stores;

namespace Sail.Administration.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IServiceStore _serviceStore;

        public ServiceController(ILogger<ServiceController> logger,IServiceStore serviceStore)
        {
            _logger = logger;
            _serviceStore = serviceStore;
        }

        public async Task<IActionResult> PageListService(int pageIndex,int pageSize)
        {
            var result = await _serviceStore.PageListServiceAsync(pageIndex, pageSize);
             return Ok(result);
        }

        public async Task<IActionResult> CreateService([FromBody]Service service)
        {
            var result = await _serviceStore.CreateServiceAsync(service);
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> FindServiceById(int id)
        {
            var result = await _serviceStore.FindServiceByIdAsync(id);
            return Ok();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _serviceStore.DeleteServiceAsync(id);
            return Ok(result);
        }
        
    }
}