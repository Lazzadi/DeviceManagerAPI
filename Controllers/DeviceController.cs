using AutoMapper;
using DeviceManagerAPI.DTO;
using DeviceManagerAPI.Interfaces;
using DeviceManagerAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors]

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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDevice([FromBody] CreateDeviceDTO createDevice)
        {
            if(createDevice == null)
            {
                return BadRequest(ModelState);
            }

            var device = _deviceRepository.GetAllDevices()
                .Where(d => d.Name.Trim().ToUpper() == createDevice.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if(device != null)
            {
                ModelState.AddModelError("", "Device already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var deviceMap = _mapper.Map<Device>(createDevice);

            if(!_deviceRepository.CreateDevice(deviceMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created device");
        }


        [HttpPut("{DeviceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDevice(int DeviceId, [FromBody] UpdateDeviceDTO updatedDevice)
        {
            if (updatedDevice == null)
                return BadRequest(ModelState);

            if(DeviceId != updatedDevice.DeviceId)
                return BadRequest(ModelState);

            if(!_deviceRepository.DeviceExists(DeviceId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var deviceMap = _mapper.Map<Device>(updatedDevice);

            if(!_deviceRepository.UpdateDevice(deviceMap))
            {
                ModelState.AddModelError("", "Something went terribly wrong :( ");
                return StatusCode(500, ModelState);
            }

            return NoContent();


        }


        [HttpDelete("{DeviceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDevice(int DeviceId)
        {
            if (!_deviceRepository.DeviceExists(DeviceId))
                return NotFound();

            var deviceToDelete = _deviceRepository.GetDeviceByID(DeviceId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_deviceRepository.DeleteDevice(deviceToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting the device");
            }

            return NoContent();
        }

    }
}
