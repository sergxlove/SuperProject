using Microsoft.Extensions.DependencyInjection;

namespace SuperProject.UseCases
{
    public partial class MongoDBCases
    {
        public static async Task UseCaseMongoDB(ServiceProvider serviceProvider)
        {
            string input = string.Empty;
            string[] parts;
            string command = string.Empty;
            string argument = string.Empty;
            string parameter = string.Empty;
            string currentCollection = string.Empty;
            string username = "root"; 
            bool exit = false;
            while(!exit)
            { 
                Console.Write($"{username}# > ");
                input = Console.ReadLine()!;
                parts = input.Split(' ', 3);
                if (parts.Length == 0) continue;
                command = parts[0].ToLower();
                argument = parts.Length > 1 ? parts[1] : string.Empty;
                parameter = parts.Length > 2 ? parts[2] : string.Empty;
                switch (command)
                {
                    case "add":
                        if(argument != string.Empty)
                        {
                            if (argument[0] == '-')
                            {
                                switch(argument)
                                {
                                    case "-s":
                                        Console.WriteLine(GetAllSchemas());
                                        break;
                                    case "-r":
                                        Console.WriteLine(AddRandomObject(parameter, currentCollection,
                                            serviceProvider));
                                        break;
                                    case "-t":
                                        break;
                                    default:
                                        Console.WriteLine(ErrorBadArgument("? add"));
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine(await AddNewObject(argument, currentCollection, serviceProvider));
                            }
                        }
                        else
                        {
                            Console.WriteLine(ErrorArgument("? add"));
                        }
                        break;
                    case "add-collection":
                        if (argument != string.Empty)
                        {
                            if (argument[0] == '-')
                            {
                                switch(argument)
                                {
                                    default:
                                        Console.WriteLine(ErrorBadArgument("? add-collection"));
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine(await CreateCollectionAsync(argument, serviceProvider));
                            }
                        }
                        break;
                    case "drop-collection":
                        if(argument != string.Empty)
                        {
                            if (argument[0] == '-')
                            {
                                switch(argument)
                                {
                                    case "-y":
                                        Console.WriteLine(await DropCollectionAsync(currentCollection, serviceProvider));
                                        currentCollection = string.Empty;
                                        break;
                                    default:
                                        Console.WriteLine(ErrorBadArgument("? drop-collection"));
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Вы уверены что хотите удалить коллекцию {currentCollection} [Y/n]");
                                Console.Write($"{username}# > ");
                                input = Console.ReadLine()!;
                                switch(input)
                                {
                                    case "Y":
                                        string result = await DropCollectionAsync(currentCollection, serviceProvider);
                                        if(result == currentCollection)
                                        {
                                            currentCollection = result;
                                        }
                                        Console.WriteLine(result);
                                        break;
                                    case "n":
                                    default:
                                        Console.WriteLine($"{currentCollection} не удалена");
                                        break;
                                }
                            }
                        }
                        break;
                    case "exit":
                        exit = true;
                        break;
                    case "get-collections":
                        Console.WriteLine(await GetCollections(argument, serviceProvider));
                        break;
                    case "help":
                        Console.WriteLine(GetHelp(argument)); 
                        break;
                    case "rename":
                        if(argument != string.Empty)
                        {
                            if (argument[0] == '-')
                            {
                                switch(argument)
                                {
                                    case "-c":
                                        Console.WriteLine($"\nТекущее имя: {username}\n");
                                        break;
                                    case "-d":
                                        username = "root";
                                        break;
                                    default:
                                        Console.WriteLine(ErrorBadArgument("? rename"));
                                        break;
                                }
                            }
                            else
                            {
                                username = argument;
                            }
                        }
                        else
                        {
                            Console.WriteLine(ErrorArgument("? rename"));
                        }
                        break;
                    case "take":
                        if(argument != string.Empty)
                        {
                            if (argument[0] == '-')
                            {
                                switch(argument)
                                {
                                    case "-c":
                                        Console.WriteLine(currentCollection);
                                        break;
                                    case "-rm":
                                        currentCollection = string.Empty;
                                        break;
                                    default:
                                        Console.WriteLine(ErrorBadArgument("? take"));
                                        break;
                                }
                            }
                            else
                            {
                                if(await CheckCollection(argument, serviceProvider))
                                {
                                    currentCollection = argument;
                                }
                                else
                                {
                                    Console.WriteLine($"Не удалось найти коллекцию {argument}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(ErrorArgument("? take"));
                        }
                        break;
                    case "version":
                        Console.WriteLine(GetVersion(argument));
                        break;
                    case "?":
                        Console.WriteLine(GetInfoCommand(argument));
                        break;
                    default:
                        Console.WriteLine(ErrorCommand(command));
                        break;
                }
            }
        }
    }
}
