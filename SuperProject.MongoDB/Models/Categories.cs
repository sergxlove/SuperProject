using MongoDB.Bson;

namespace SuperProject.MongoDB.Models
{
    public class Categories
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public static Categories? Convert(string str)
        {
            Categories? category = null;
            string[] parts = str.Split(", ", 2);
            if(parts.Length == 2)
            {
                category = new Categories()
                {
                    Name = parts[0],
                    Description = parts[1]
                };
            }
            return category;
        }

        public static string GetSchemaCategories()
        {
            return "Схема categories: name, description";
        }
    }
}
