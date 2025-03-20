using MongoDB.Bson;

namespace SuperProject.MongoDB.Models
{
    public class Users
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime DateRegistration { get; set; } = DateTime.UtcNow;

        public static Users? Convert(string str)
        {
            Users? result = null;
            string[] parts = str.Split(", ", 2);
            if(parts.Length == 2)
            {
                result = new Users()
                {
                    Username = parts[0],
                    Password = parts[1],
                };
            }
            return result;
        }

        public static string GetSchemaUsers()
        {
            return "Схема users: username, password";
        }
    }
}
