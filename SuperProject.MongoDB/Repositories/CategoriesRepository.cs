using MongoDB.Bson;
using MongoDB.Driver;
using SuperProject.MongoDB.Abstractions;
using SuperProject.MongoDB.Models;

namespace SuperProject.MongoDB.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public readonly IMongoDbContext _context;

        public CategoriesRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Categories categories)
        {
            await _context.CategoriesCollection.InsertOneAsync(categories);
        }

        public async Task<List<Categories>> ReadAsync(BsonDocument filter)
        {
            var result = await _context.CategoriesCollection.FindAsync(filter);
            return result.ToList();
        }

        public async Task<long> UpdateAsync(BsonDocument filter, Categories categories)
        {
            var result = await _context.CategoriesCollection.ReplaceOneAsync(filter, categories);
            return result.ModifiedCount;
        }

        public async Task<long> DeleteAsync(BsonDocument filter)
        {
            var result = await _context.CategoriesCollection.DeleteOneAsync(filter);
            return result.DeletedCount;
        }
    }
}
