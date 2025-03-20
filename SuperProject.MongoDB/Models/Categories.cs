using MongoDB.Bson;

namespace SuperProject.MongoDB.Models
{
    public class Categories
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
