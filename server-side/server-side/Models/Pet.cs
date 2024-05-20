using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace server_side.Models
{
    public class Pet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }

        public DateTime? Created_At { get; set; }

        public string? type { get; set; }
        
        public string? age { get; set; }

        public string? color { get; set; }
    }
}
