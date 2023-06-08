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

        public ICollection<Devices> GetAllDevices()
        {
            return _context.Devices
                .Include(device => device.User)
                .OrderBy(device => device.DeviceId)
                .ToList();
        }

        public Devices GetDeviceByID(int DeviceID)
        {
            return _context.Devices
                .Where(device => device.DeviceId == DeviceID)
                .FirstOrDefault();
        }

    }
}
