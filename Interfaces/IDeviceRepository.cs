using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Interfaces
{
    public interface IDeviceRepository
    {

        
        ICollection<Device> GetAllDevices();

        Device GetDeviceByID(int DeviceID); 

        bool DeviceExists(int DeviceID);

        bool CreateDevice(Device device);
        bool UpdateDevice(Device device);
        bool DeleteDevice(Device device);

        bool Save();

    }
}
