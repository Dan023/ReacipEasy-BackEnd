using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using ReacipEasy.Models.Base;

namespace ReacipEasy.Models
{
    public class RecipeModel : BasicModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public float Time { get; set; }
        public bool IsFavorite { get; set; } = false;
        public List<string> Ingredients { get; set; } = new List<string>();
        public int Difficulty { get; set; }
        public UserModel User { get; set; } = new UserModel();
    }
}
