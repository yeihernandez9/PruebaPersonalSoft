using System;
using MongoDB.Bson;
using MongoDB.Driver;
using PruebaPersonalSoft.Models;

namespace PruebaPersonalSoft.Repositories.Polizas
{
	public class PolizaCollection : IPolizaCollection
	{
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Models.Poliza> Collection;

        public PolizaCollection()
        {
            Collection = _repository.db.GetCollection<Models.Poliza>("Polizas");
        }
	

        public async Task DeletePoliza(string id)
        {
            var filter = Builders<Models.Poliza>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Poliza>> GetAllPoliza()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Poliza> GetPolizaById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task IserttPoliza(Poliza poliza)
        {
            await Collection.InsertOneAsync(poliza);
        }

        public async Task UpdatePoliza(Poliza poliza)
        {
            var filter = Builders<Poliza>
                .Filter
                .Eq(s => s.Id, poliza.Id);

            await Collection.ReplaceOneAsync(filter, poliza);
        }
    }
}

