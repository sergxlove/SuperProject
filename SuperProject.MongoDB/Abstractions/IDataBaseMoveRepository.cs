﻿using MongoDB.Bson;

namespace SuperProject.MongoDB.Abstractions
{
    public interface IDataBaseMoveRepository
    {
        Task<string> GetCollectionsAsync();
        Task<bool> CheckCollectionAsync(string nameCollection);
        Task<string> CreateCollectionAsync(string nameCollection);
        Task<string> DropCollectionAsync(string nameCollection);
        Task<string> AddRandomObjectAsync(string nameCollection, BsonDocument obj);
    }
}
