using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReacipEasy.Models.Base
{
    public class BasicModel
    {
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
