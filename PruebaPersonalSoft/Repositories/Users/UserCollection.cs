using System;
using Amazon.Auth.AccessControlPolicy;
using MongoDB.Bson;
using MongoDB.Driver;
using PruebaPersonalSoft.Models;

namespace PruebaPersonalSoft.Repositories.Users
{
	public class UserCollection : IUserCollection
	{
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Models.User> Collection;

        public UserCollection()
        {
            Collection = _repository.db.GetCollection<Models.User>("Users");
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var filter = Builders<User>.Filter.Eq(x => x.email, email) & Builders<User>.Filter.Eq(x => x.password, password);
            return await Collection.FindAsync(filter).Result.FirstAsync();
        }

        public async Task DeleteUserPoliza(string id)
        {
            var filter = Builders<Models.User>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<User> GetUser(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

       
        public async Task InsertUser(User user)
        {
            await Collection.InsertOneAsync(user);
        }


        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>
               .Filter
               .Eq(s => s.Id, user.Id);

            await Collection.ReplaceOneAsync(filter, user);
        }

    }
}

