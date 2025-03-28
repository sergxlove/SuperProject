﻿using SuperProject.MongoDB.Abstractions;
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
    }
}
