using Microsoft.Extensions.DependencyInjection;
using SuperProject.Application.Abstractions;

namespace SuperProject.UseCases
{
    public partial class MongoDBCases
    {
        private static string GetHelp(string args)
        {
            string information = "\n" +
                "exit - выход из программы\n" +
                "get-collections - получение списка всех коллекций\n" +
                "help - вывод краткой информации о программе\n" +
                "rename - переименовать пользователя\n" +
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
                case "get-collections":
                    information += "\n" +
                        "Структура: [command] [argument]\n" +
                        "\nОтвечает за вывод названий доступных коллекций.\n" +
                        "Аргументы:\n";
                    break;
                case "rename":
                    information = "\n" +
                        "Структура: [command] [argument]\n" +
                        "\nОтвечает за переименование имени пользователя.\n" +
                        "Аргументы:\n" +
                        "-c : вывод текущего имени пользвателя\n" +
                        "-d : сброс имени пользователя\n";
                    break;
                case "take":
                    information += "\n" +
                        "Структура: [command] [argument]\n" +
                        "Отвечает за выбор активной коллекции в базе данных.\n" +
                        "Аргументы:\n" +
                        "-rm : сбросить выбранную коллекцию\n" +
                        "-c : вывод текущей выбранной коллекции\n";
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
    }
}
