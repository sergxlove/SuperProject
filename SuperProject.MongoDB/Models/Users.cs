using MongoDB.Bson;

namespace SuperProject.MongoDB.Models
{
    public class Users
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime DateRegistration { get; set; } = DateTime.UtcNow;
    }
}
