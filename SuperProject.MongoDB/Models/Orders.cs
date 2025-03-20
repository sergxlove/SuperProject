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

        public static Orders? Convert(string str)
        {
            Orders? result = null;
            string[] parts = str.Split(", ", 4);
            if (parts.Length == 4)
            {
                result = new()
                {
                    Name = parts[0],
                    Description = parts[1],
                    Price = System.Convert.ToInt32(parts[2]),
                    Stoke = System.Convert.ToInt32(parts[3])
                };
            }
            return result;
        }

        public static string GetSchemaOrders()
        {
            return "Схема orders: name, description, price, stoke";
        }
    }
}
