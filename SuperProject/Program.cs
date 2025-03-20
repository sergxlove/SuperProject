using Microsoft.Extensions.DependencyInjection;
using SuperProject.Application.Abstractions;
using SuperProject.Application.Services.MongoDb;
using SuperProject.MongoDB;
using SuperProject.MongoDB.Abstractions;
using SuperProject.MongoDB.Models;
using SuperProject.MongoDB.Repositories;
using SuperProject.UseCases;

namespace SuperProject
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IMongoDbContext ,MongoDbContext>();
            serviceCollection.AddScoped<ICategoriesRepository, CategoriesRepository>();
            serviceCollection.AddSingleton<IDataBaseMoveRepository, DataBaseMoveRepository>();
            serviceCollection.AddScoped<IOrdersRepository, OrdersRepository>();
            serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
            serviceCollection.AddScoped<ICategoriesService, CategoriesService>();
            serviceCollection.AddSingleton<IDataBaseMoveService,  DataBaseMoveService>();
            serviceCollection.AddScoped<IOrdersService, OrdersService>();
            serviceCollection.AddScoped<IUsersService, UsersService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            await MongoDBCases.UseCaseMongoDB(serviceProvider);
        }
    }
}
