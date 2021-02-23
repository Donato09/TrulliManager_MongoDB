using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TrulliManager.Database.Models
{
    public class Trullo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        //public Property Property { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Property { get; set; }
    }
}
