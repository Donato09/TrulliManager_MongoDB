using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace TrulliManager.Database.Models
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("Street")]
        public string Street { get; set; }

        [BsonElement("Spa")]
        public bool Spa { get; set; }

        [BsonElement("SwimmingPool")]
        public bool SwimmingPool { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        //public List<string> Trulli { get; set; }

        [BsonIgnore]
        public List<Trullo> TrulloList { get; set; }
    }
}
