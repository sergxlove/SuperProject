using MongoDB.Bson;
using SuperProject.Application.Abstractions;
using SuperProject.MongoDB.Abstractions;
using SuperProject.MongoDB.Models;

namespace SuperProject.Application.Services.MongoDb
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task CreateNewOrderAsync(Orders order)
        {
            await _ordersRepository.CreateAsync(order);
        }

        public async Task<List<Orders>> ReadOrdersAsync(BsonDocument filter)
        {
            return await _ordersRepository.ReadAsync(filter);
        }

        public async Task<long> UpdateOrderAsync(BsonDocument filter, Orders order)
        {
            return await _ordersRepository.UpdateAsync(filter, order);
        }

        public async Task<long> DeleteOrdersAsync(BsonDocument filter)
        {
            return await _ordersRepository.DeleteAsync(filter);
        }
    }
}
