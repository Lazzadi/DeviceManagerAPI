using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUserByID(int UserID);

        bool UserExists(int UserID);
    }
}
