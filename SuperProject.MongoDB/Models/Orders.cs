using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperProject.MongoDB.Models
{
    public class Orders
    {
        public ObjectId Id { get; set; }

        [BsonIgnoreIfDefault]
        public string Name { get; set; } = string.Empty;


        [BsonIgnoreIfDefault]
        public string Description { get; set; } = string.Empty;


        [BsonIgnoreIfDefault]
        public int Price { get; set; }


        [BsonIgnoreIfDefault]
        public int Stoke { get; set; }
    }
}
