using MongoDB.Driver;
using SuperProject.MongoDB.Abstractions;
using SuperProject.MongoDB.Models;

namespace SuperProject.MongoDB
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly MongoClient _client;

        public IMongoCollection<Users> UsersCollection { get; set; }

        public IMongoCollection<Orders> OrdersCollection { get; set; }

        public IMongoCollection<Categories> CategoriesCollection { get; set; }

        public IMongoDatabase Database { get; set; }

        public MongoDbContext(string connectionString = "mongodb://localhost:27017", string nameDatabase = "test")
        {
            _client = new MongoClient(connectionString);

            Database = _client.GetDatabase(nameDatabase);
            var collections = Database.ListCollectionNames().ToList();
            List<Task> tasks = new List<Task>();
            if(!collections.Contains(nameof(Users)))
            {
                tasks.Add(Task.Run(() => { Database.CreateCollectionAsync(nameof(Users)); }));
            }

            if(!collections.Contains(nameof(Orders)))
            {
                tasks.Add(Task.Run(() => { Database.CreateCollectionAsync(nameof(Orders)); }));
            }

            if(!collections.Contains(nameof(Categories)))
            {
                tasks.Add(Task.Run(() => { Database.CreateCollectionAsync(nameof(Categories)); }));
            }

            if(tasks.Any())
            {
                Task.WaitAll(tasks);
            }

            UsersCollection = Database.GetCollection<Users>(nameof(Users));
            OrdersCollection = Database.GetCollection<Orders>(nameof(Orders));
            CategoriesCollection = Database.GetCollection<Categories>(nameof(Categories));
        }


    }
}
