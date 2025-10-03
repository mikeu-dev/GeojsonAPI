using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GeojsonAPI.Models.User
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }

        [BsonElement("username")]
        public required string Username { get; set; }

        [BsonElement("email")]
        public required string Email { get; set; }

        [BsonElement("passwordHash")]
        public required string PasswordHash { get; set; }

        [BsonElement("role")]
        public string Role { get; set; } = "User";
    }
}
