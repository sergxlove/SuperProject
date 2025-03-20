using MongoDB.Bson;
using SuperProject.Application.Abstractions;
using SuperProject.MongoDB.Abstractions;
using SuperProject.MongoDB.Models;

namespace SuperProject.Application.Services.MongoDb
{ 
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task CreateNewCategoryAsync(Categories categories)
        {
            await _categoriesRepository.CreateAsync(categories);
        }

        public async Task<List<Categories>> ReadCategoriesAsync(BsonDocument filter)
        {
            return await _categoriesRepository.ReadAsync(filter);
        }

        public async Task<long> UpdateCategoriesAsync(BsonDocument filter, Categories categories)
        {
            return await _categoriesRepository.UpdateAsync(filter, categories);
        }

        public async Task<long> DeleteCategoriesAsync(BsonDocument filter)
        {
            return await _categoriesRepository.DeleteAsync(filter);
        }
    }
}
