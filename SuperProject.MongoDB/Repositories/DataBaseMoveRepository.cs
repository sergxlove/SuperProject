using SuperProject.MongoDB.Abstractions;
using MongoDB.Driver;
using System.Text;
using MongoDB.Bson;

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

        public async Task<string> CreateCollectionAsync(string nameCollection)
        {
            await _context.Database.CreateCollectionAsync(nameCollection);
            if(await CheckCollectionAsync(nameCollection))
            {
                return nameCollection;
            }
            return string.Empty;
        }

        public async Task<string> RenameCollectionAsync(string oldName, string newName)
        {
            try
            {
                await _context.Database.RenameCollectionAsync(oldName, newName);
                return newName;
            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }

        public async Task<string> DropCollectionAsync(string nameCollection)
        {
            await _context.Database.DropCollectionAsync(nameCollection);
            if(!await CheckCollectionAsync(nameCollection))
            {
                return nameCollection;
            }
            return string.Empty;
        }

        public async Task<string> AddRandomObjectAsync(string nameCollection, BsonDocument obj)
        {
            try
            {
                var collection = _context.Database.GetCollection<BsonDocument>(nameCollection);
                await collection.InsertOneAsync(obj);
                return obj.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteRandomObjectOneAsync(string nameCollection, 
            BsonDocument filter)
        {
            try
            {
                var collection = _context.Database.GetCollection<BsonDocument>(nameCollection);
                var result = await collection.DeleteOneAsync(filter);
                return result.DeletedCount.ToString();
            }
            catch
            {
                return "0";
            }
        }

        public async Task<string> DeleteRandomObjectManyAsync(string nameCollection, 
            BsonDocument filter)
        {
            try
            {
                var collection = _context.Database.GetCollection<BsonDocument>(nameCollection);
                var result = await collection.DeleteManyAsync(filter);
                return result.DeletedCount.ToString();
            }
            catch
            {
                return "0";
            }
        }

        public async Task<string> UpdateRandomObjectOneAsync(string nameCollection,
            BsonDocument filter, BsonDocument obj)
        {
            try
            {
                var collection = _context.Database.GetCollection<BsonDocument>(nameCollection);
                var result = await collection.UpdateOneAsync(filter, obj);
                return result.ModifiedCount.ToString();
            }
            catch
            {
                return "0";
            }
        }

        public async Task<string> UpdateRandomObjectManyAsync(string nameCollection,
            BsonDocument filter, BsonDocument obj)
        {
            try
            {
                var collection = _context.Database.GetCollection<BsonDocument>(nameCollection);
                var result = await collection.UpdateManyAsync(filter, obj);
                return result.ModifiedCount.ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}
