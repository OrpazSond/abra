using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace server_side.Models
{
    //I planned to define the type to be modular but I didn't have time to realize it
    public class PetType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? TypeName { get; set; }

    }
}
