using MongoDB.Bson;
using MongoDB.Driver;
using SuperProject.MongoDB.Abstractions;
using SuperProject.MongoDB.Models;

namespace SuperProject.MongoDB.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly IMongoDbContext _context;

        public OrdersRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Orders order)
        {
            await _context.OrdersCollection.InsertOneAsync(order);
        }

        public async Task<List<Orders>> ReadAsync(BsonDocument filter)
        {
            var result = await _context.OrdersCollection.FindAsync(filter);
            return result.ToList();
        }

        public async Task<long> UpdateAsync(BsonDocument filter, Orders order)
        {
            var result = await _context.OrdersCollection.ReplaceOneAsync(filter, order);
            return result.MatchedCount;
        }

        public async Task<long> DeleteAsync(BsonDocument filter)
        {
            var result = await _context.OrdersCollection.DeleteOneAsync(filter);
            return result.DeletedCount;
        }
    }
}
