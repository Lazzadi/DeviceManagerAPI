using DeviceManagerAPI.Data;
using DeviceManagerAPI.Interfaces;
using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DataContext _context;

        public DeviceRepository(DataContext context) 
        {
            _context = context;
        }

        public ICollection<Devices> GetDevices()
        {
            return _context.Devices.OrderBy(p => p.DeviceId).ToList();
        }
    }
}
