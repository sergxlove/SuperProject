using SuperProject.MongoDB.Abstractions;
using MongoDB.Driver;
using System.Text;

namespace SuperProject.MongoDB.Repositories
{
    public class DataBaseMoveRepository : IDataBaseMoveRepository
    {
        private readonly IMongoDbContext _context;

        public DataBaseMoveRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetCollectionsAsync()
        {
            var collection = await _context.Database.ListCollectionNamesAsync();
            StringBuilder result = new StringBuilder();
            foreach (var collectionName in collection.ToList())
            {
                result.Append(collectionName + "\n");
            }
            return result.ToString();
        }

        public async Task<bool> CheckCollectionAsync(string nameCollection)
        {
            var collection = await _context.Database.ListCollectionNamesAsync();
            foreach (var collectionName in collection.ToList())
            {
                if (collectionName == nameCollection) return true;
            }
            return false;
        }
    }
}
