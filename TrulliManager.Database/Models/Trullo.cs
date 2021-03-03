using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace TrulliManager.Database.Models
{
    public class Trullo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public string Property_id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        [BsonIgnore]
        public Property Property { get; set; }
    }
}
