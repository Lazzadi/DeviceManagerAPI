using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<Users> GetUsers();
    }
}
