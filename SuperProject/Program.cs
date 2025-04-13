using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperProject.Application.Abstractions;
using SuperProject.Application.Services.MongoDb;
using SuperProject.Messaging.Kafka;
using SuperProject.Messaging.Kafka.Abstractions;
using SuperProject.Messaging.Kafka.Handlers;
using SuperProject.Messaging.Kafka.Models;
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
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("D:\\projects\\SuperProject\\SuperProject\\appsettings.json")
                .Build();
        
            var serviceCollection = new ServiceCollection();
            serviceCollection.Configure<KafkaSettings>(config.GetSection("Kafka:Order"));
            serviceCollection.AddSingleton<IMongoDbContext ,MongoDbContext>();
            serviceCollection.AddSingleton<IKafkaProducer<Order>, KafkaProducer<Order>>();
            serviceCollection.AddHostedService<KafkaConsumer<Order>>();
            serviceCollection.AddSingleton<IMessageHandler<Order>, MessageHandler>();
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
