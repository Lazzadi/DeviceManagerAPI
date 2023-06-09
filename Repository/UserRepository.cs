﻿using DeviceManagerAPI.Data;
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

        public ICollection<Users> GetUsers()
        {
            return _context.Users.OrderBy(p => p.UserId).ToList();
        }

        public Users GetUserByID(int UserID)
        {
            return _context.Users
                .Where(user => user.UserId == UserID)
                .FirstOrDefault();
        }
    }
}
