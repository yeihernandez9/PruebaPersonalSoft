using System;
using System.Numerics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PruebaPersonalSoft.Models
{
	public class Poliza
	{
        [BsonId]
        public ObjectId Id { get; set; }
		public int poliza { get; set; }
		public string clientName { get; set; }
		public string clientIdentification { get; set; }
        public string dateBirth { get; set; }
        public string dateCretePolicy { get; set; }
        public string coverage { get; set; }
		public string valueMax { get; set; }
        public string planPolicyName { get; set; }
        public string homeCity { get; set; }
        public string addressHome { get; set; }
        public string placa { get; set; }
        public string modelo { get; set; }
        public bool inspeccion { get; set; }
    }
}

