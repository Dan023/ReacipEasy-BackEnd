using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ReacipEasy.Models.Base;

namespace ReacipEasy.Models
{
    public class UserModel : BasicModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
