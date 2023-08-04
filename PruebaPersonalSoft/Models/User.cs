using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PruebaPersonalSoft.Models
{
	public class User
	{
		[BsonId]
        public ObjectId Id { get; set; }
		public string email { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
    }
}

