using System;
using PruebaPersonalSoft.Models;
using PruebaPersonalSoft.Repositories.Users;

namespace PruebaPersonalSoft.Services
{
    public class UserService
    {
        public IUserCollection db = new UserCollection();

        public async Task<List<User>> GetUsers()
        {
            var response = await db.GetAllUsers();
            return response;
        }

        public async Task<User> AddUser(User user)
        {
            await db.InsertUser(user);

            return user;
        }
    }
}

