using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Interfaces
{
    public interface IDeviceRepository
    {
        
        

        //Update an existing item
        //Delete a specific item
        //Show all devices in a list with the user who is using it
        //select a device to view its dtails
        //create a new device (validate that the item doesn't already exist and validate all fields have values
        //update an existing device
        //delete a device directly from the list
        
        ICollection<Device> GetAllDevices(); //Load data from the DB

        Device GetDeviceByID(int DeviceID); //Select an item from the DB based on an ID + Add validation in case device ID is incorrect

        bool DeviceExists(int DeviceID);

        bool CreateDevice(Device device);
        bool UpdateDevice(Device device);

        bool Save();

    }
}
