using MongoDB.Bson;
using MongoDB.Driver;
using SuperProject.MongoDB.Abstractions;
using SuperProject.MongoDB.Models;

namespace SuperProject.MongoDB.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoDbContext _context;

        public UsersRepository(IMongoDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Users users)
        {
            await _context.UsersCollection.InsertOneAsync(users);
        }

        public async Task<List<Users>> ReadAsync(BsonDocument filter)
        {
            var result = await _context.UsersCollection.FindAsync(filter);
            return result.ToList();
        }

        public async Task<long> UpdateAsync(BsonDocument filter, Users users)
        {
            var result = await _context.UsersCollection.ReplaceOneAsync(filter, users);
            return result.ModifiedCount; 
        }

        public async Task<long> DeleteAsync(BsonDocument filter)
        {
            var result = await _context.UsersCollection.DeleteOneAsync(filter);
            return result.DeletedCount;
        }

    }
}
