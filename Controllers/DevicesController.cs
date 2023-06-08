using DeviceManagerAPI.Interfaces;
using DeviceManagerAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagerAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Devices>))]

        public IActionResult GetAllDevices()
        {
            var users = _deviceRepository.GetAllDevices();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }
    }
}
