using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUserByID(int UserID);

        User GetUserByEmail(string Email);
        User LoginUser(string email, string password);
        bool UserExists(int UserID);
        bool CreateUser(User user);

    }
}
