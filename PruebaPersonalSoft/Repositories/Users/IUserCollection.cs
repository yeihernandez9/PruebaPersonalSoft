using System;
namespace PruebaPersonalSoft.Repositories.Users
{
	public interface IUserCollection
	{
		Task InsertUser(Models.User user);

		Task UpdateUser(Models.User user);

		Task DeleteUserPoliza(string id);

		Task<List<Models.User>> GetAllUsers();

		Task<Models.User> GetUser(string id);

		Task<Models.User> Authenticate(string email, string password);
    }
}

