using DeviceManagerAPI.Data;
using DeviceManagerAPI.Interfaces;
using DeviceManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagerAPI.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context) 
        {
            _context = context;
        }

        public ICollection<Device> GetAllDevices()
        {
            return _context.Devices
                .Include(device => device.User)
                .OrderBy(device => device.DeviceId)
                .ToList();
        }

        public Device GetDeviceByID(int DeviceId)
        {
            return _context.Devices
                .Include(device => device.User)
                .Where(device => device.DeviceId == DeviceId)
                .FirstOrDefault();
        }

        public bool DeviceExists(int DeviceId)
        {
            return _context.Devices.Any(device => device.DeviceId == DeviceId);
        }

    }
}
