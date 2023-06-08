using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Interfaces
{
    public interface IDeviceRepository
    {
        ICollection<Devices> GetDevices();
    }
}
