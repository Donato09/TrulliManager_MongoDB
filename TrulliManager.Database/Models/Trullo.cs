using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TrulliManager.Database.Models
{
    public class Trullo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Trullo_id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Property_id { get; set; }

    }
}
