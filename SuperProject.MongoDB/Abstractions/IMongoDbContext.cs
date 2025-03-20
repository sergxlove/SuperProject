using MongoDB.Driver;
using SuperProject.MongoDB.Models;

namespace SuperProject.MongoDB.Abstractions
{
    public interface IMongoDbContext
    {
        IMongoCollection<Categories> CategoriesCollection { get; set; }
        IMongoCollection<Orders> OrdersCollection { get; set; }
        IMongoCollection<Users> UsersCollection { get; set; }
        IMongoDatabase Database { get; set; }
    }
}
