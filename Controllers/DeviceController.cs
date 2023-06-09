using AutoMapper;
using DeviceManagerAPI.DTO;
using DeviceManagerAPI.Interfaces;
using DeviceManagerAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagerAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceController(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Device>))]

        public IActionResult GetAllDevices()
        {
            var devices = _mapper.Map<List<DeviceDTO>>(_deviceRepository.GetAllDevices());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(devices);
        }

        [HttpGet("{DeviceID}", Name = "GetDeviceByID")]
        [ProducesResponseType(200, Type = typeof(Device))]
        public IActionResult GetDeviceByID(int DeviceID)
        {
            if(!_deviceRepository.DeviceExists(DeviceID))
            {
                return NotFound();
            }
            
            var devices = _mapper.Map<Device>(_deviceRepository.GetDeviceByID(DeviceID));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(devices);
        }

    }
}
