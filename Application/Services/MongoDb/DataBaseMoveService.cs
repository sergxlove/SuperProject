using SuperProject.Application.Abstractions;
using SuperProject.MongoDB.Abstractions;

namespace SuperProject.Application.Services.MongoDb
{
    public class DataBaseMoveService : IDataBaseMoveService
    {
        private readonly IDataBaseMoveRepository _repository;

        public DataBaseMoveService(IDataBaseMoveRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetAllCollectionsAsync()
        {
            return await _repository.GetCollectionsAsync();
        }

        public async Task<bool> CheckCollectionAsync(string nameCollection)
        {
            return await _repository.CheckCollectionAsync(nameCollection);
        }

        public async Task<string> CreateCollectionAsync(string nameCollection)
        {
            return await _repository.CreateCollectionAsync(nameCollection);
        }

        public async Task<string> DropCollectionAsync(string nameCollection)
        {
            return await _repository.DropCollectionAsync(nameCollection);
        }
    }
}
