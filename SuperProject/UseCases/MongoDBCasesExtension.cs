using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using SuperProject.Application.Abstractions;
using SuperProject.Application.Services.MongoDb;
using SuperProject.MongoDB.Models;
using System.Text;

namespace SuperProject.UseCases
{
    public partial class MongoDBCases
    {
        private static string GetHelp(string args)
        {
            string information = "\n" +
                "add - добавление элемента\n" +
                "add-collection - создание новой коллекции\n" +
                "drop-collection - удаление коллекции\n" +
                "exit - выход из программы\n" +
                "get-collections - получение списка всех коллекций\n" +
                "help - вывод краткой информации о программе\n" +
                "rename - переименовать пользователя\n" +
                "rename-collection - переименовать коллекцию\n" +
                "take - выбор коллекции\n" +
                "version - вывод информации о версии программы\n" +
                "? [command] - вывод подробной информации о команде\n";
            return information;
        }

        private static string GetVersion(string args)
        {
            string information = "\n" +
                "Версия 1.0.0, developer sergxlove, 2025\n" +
                "Все права защищены\n";
            return information;
        }

        private static string GetInfoCommand(string args)
        {
            string information = "\n";
            switch (args)
            {
                case "add":
                    information += "\n" +
                        "Структура: [command] [argument] [parameter]\n" +
                        "Отвечает за добавление элементов в коллекцию.\n" +
                        "Аргументы:\n" +
                        "-s : вывод всех доступных схем\n" +
                        "-t : вывод примеров объектов\n" +
                        "-r : добавление произвольного объекта в коллекцию\n";
                    break;
                case "add-collection":
                    information += "\n" +
                        "Структура: [command] [argument] [parameter]\n" +
                        "Отвечает за создание новой коллекции \n" +
                        "Аргументы:\n";
                    break;
                case "drop-collection":
                    information += "\n" +
                        "Структура: [command] [argument] [parameter]\n" +
                        "Отвечает за удаление существующей коллекции \n" +
                        "Аргументы:\n" +
                        "-y : удаление коллекций без подтверждения\n";
                    break;
                case "get-collections":
                    information += "\n" +
                        "Структура: [command] [argument] [parameter]\n" +
                        "Отвечает за вывод названий доступных коллекций.\n" +
                        "Аргументы:\n";
                    break;
                case "help":
                    information += "\n" +
                        "Структура: [command] [argument] [parameter]\n" +
                        "Отвечает за вывод информации о доступных командах\n" +
                        "Аргументы:\n";
                    break;
                case "rename":
                    information = "\n" +
                        "Структура: [command] [argument] [parameter]\n" +
                        "Отвечает за переименование имени пользователя.\n" +
                        "Аргументы:\n" +
                        "-c : вывод текущего имени пользвателя\n" +
                        "-d : сброс имени пользователя\n";
                    break;
                case "rename-collection":
                    break;
                case "take":
                    information += "\n" +
                        "Структура: [command] [argument] [parameter]\n" +
                        "Отвечает за выбор активной коллекции в базе данных.\n" +
                        "Аргументы:\n" +
                        "-rm : сбросить выбранную коллекцию\n" +
                        "-c : вывод текущей выбранной коллекции\n";
                    break;
                case "version":
                    break;
                default:
                    break;
            }
            return information;
        }

        private async static Task<string> GetCollections(string args, ServiceProvider services)
        {
            try
            {
                var dbService = services.GetService<IDataBaseMoveService>();
                if (dbService == null) throw new Exception(new("Ошибка получения сервиса IDataBaseMoveService"));
                string result = await dbService.GetAllCollectionsAsync();
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private async static Task<bool> CheckCollection(string args, ServiceProvider services)
        {
            try
            {
                var dbService = services.GetService<IDataBaseMoveService>();
                if (dbService == null) throw new Exception();
                if (await dbService.CheckCollectionAsync(args)) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static string ErrorArgument(string command)
        {
            return $"Необходимо передать аргумент.\nДля получения помощи воспользуйтесь командой: {command}\n";             
        }

        private static string ErrorBadArgument(string command)
        {
            return $"Неверный аргумент.\nДля получения помощи воспользуйтесь командой: {command}\n";
        }

        private static string ErrorCommand(string command)
        {
            return $"Не удалось найти комманду {command}. \nДля получения помощи воспользуйтесь командой: help";
        }

        private static async Task<string> AddNewObject(string args, string currentCollection, ServiceProvider services)
        {
            switch(currentCollection)
            {
                case "Users":
                    try
                    {
                        var usersService = services.GetService<IUsersService>();
                        if (usersService is null)
                        {
                            return "Не найден сервис userService";
                        }
                        var user = Users.Convert(args);
                        if(user is null)
                        {
                            return "Неверный ввод. Для вызова схем воспользуйтесь командой : Add -s";
                        }
                        await usersService.CreateNewUserAsync(user);
                        return "Добавлено";
                    }
                    catch(Exception ex)
                    {
                        return ex.Message;
                    }
                case "Orders":
                    try
                    {
                        var ordersService = services.GetService<IOrdersService>();
                        if(ordersService is null)
                        {
                            return "Не найден сервис ordersService";
                        }
                        var order = Orders.Convert(args);
                        if(order is null)
                        {
                            return "Неверный ввод. Для вызова схем воспользуйтесь командой : Add -s";
                        }
                        return "Добавлено";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                case "Categories":
                    try
                    {
                        var categoriesService = services.GetService<ICategoriesService>();
                        if(categoriesService is null)
                        {
                            return "Не найден сервис categoriesService";
                        }
                        var category = Categories.Convert(args);
                        if(category is null)
                        {
                            return "Неверный ввод. Для вызова схем воспользуйтесь командой : Add -s";
                        }
                        return "Добавлено";
                    }
                    catch(Exception ex)
                    {
                        return ex.Message;
                    }
                default:
                    break;
            }
            return string.Empty;
        }

        private static string GetAllSchemas()
        {
            return $"{Categories.GetSchemaCategories()}\n{Orders.GetSchemaOrders()}\n" +
                $"{Users.GetSchemaUsers()}\n{GetSchemasBson()}\n";
        }

        private static string GetSchemasBson()
        {
            return "Схема произвольной коллекции:" +
                "{ \"param1\": \"value1\", \"param2\": \"value2\", ... \"paramN\": \"valueN\" }";
        }

        private static string GetTemplatesObjects()
        {
            return $"Шаблон объекта Categories: sergxlove, its great developer" +
                $"\nШаблон объекта Orders: milk, is cool, 100, 12" +
                $"\nШаблон объекта Users: sergxlove, megapassword" +
                "\nШаблон для произвольного объекта: { \"name\": \"sergxlove\", \"age\": \"18\" }";
        }

        private static async Task<string> AddRandomObject(string str, string nameCollection,
            ServiceProvider services)
        {
            try
            {
                var dataBaseMoveService = services.GetService<IDataBaseMoveService>();
                if (dataBaseMoveService is null)
                {
                    return "Не удалось найти сервис IDataBaseMMoveService";
                }
                string result = await dataBaseMoveService.AddRandomObjectAsync(
                    nameCollection, BsonDocument.Parse(str));
                if(str == result)
                {
                    return result + "  добавлен";
                }
                return "Произошла ошибка добавления объекта";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        private static string EraseArgument(string str)
        {
            if(str.Length >= 2)
            {
                StringBuilder result = new StringBuilder();
                for(int i = 2; i < str.Length; i++)
                {
                    result.Append(str[i]);
                }
                return result.ToString();
            }
            return string.Empty;
        }

        private static async Task<string> CreateCollectionAsync(string nameCollection,
            ServiceProvider services)
        {
            try
            {
                var dataBaseMoveService = services.GetService<IDataBaseMoveService>();
                if(dataBaseMoveService is null)
                {
                    return "Не удалось найти сервис IDataBaseMMoveService";
                }
                string result = await dataBaseMoveService.CreateCollectionAsync(nameCollection);
                if(result == nameCollection)
                {
                    return result;
                }
            }
            catch(Exception ex)
            {
                return ex.Message; 
            }
            return string.Empty;
        }

        private static async Task<string> DropCollectionAsync(string nameCollection,
            ServiceProvider services)
        {
            try
            {
                var dataBaseMoveService = services.GetService<IDataBaseMoveService>();
                if (dataBaseMoveService is null)
                {
                    return "Не удалось найти сервис IDataBaseMMoveService";
                }
                string result = await dataBaseMoveService.DropCollectionAsync(nameCollection);
                if (result == nameCollection)
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
    }
}
