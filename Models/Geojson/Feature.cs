using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace GeojsonAPI.Models.GeoJSON
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public string Name { get; set; } = "Feature";
        public required Geometry Geometry { get; set; } = new Geometry
        {
            Type = string.Empty,
            Coordinates = []
        };
        public required Properties Properties { get; set; } = new Properties();
    }
}
