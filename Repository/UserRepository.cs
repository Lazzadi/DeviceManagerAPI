using DeviceManagerAPI.Data;
using DeviceManagerAPI.Interfaces;
using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) 
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(p => p.UserId).ToList();
        }

        public User GetUserByID(int UserID)
        {
            return _context.Users
                .Where(user => user.UserId == UserID)
                .FirstOrDefault();
        }
    }
}
