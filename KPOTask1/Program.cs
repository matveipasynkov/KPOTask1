using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Models.Animals;
using Models.Things;
using Services;
class Program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddSingleton<VeterinaryClinic>();
        services.AddSingleton<Zoo>();
        var provider = services.BuildServiceProvider();

        var zoo = provider.GetService<Zoo>();

        while (true)
        {
            Console.WriteLine("1. Добавить животное в зоопарк");
            Console.WriteLine("2. Добавить предмет в инвентарь");
            Console.WriteLine("3. Просмотреть список всех животных");
            Console.WriteLine("4. Посчитать потребляемую еду");
            Console.WriteLine("5. Показать список контактных животных");
            Console.WriteLine("6. Просмотреть инвентаризационные номера");
            Console.WriteLine("7. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Введите имя животного: ");
                    string? name = Console.ReadLine();
                    Console.Write("Введите количество еды (кг/сутки): ");
                    int food = int.Parse(Console.ReadLine());
                    Console.Write("Здорово ли животное? (да/нет): ");
                    bool isHealthy = Console.ReadLine().ToLower() == "да";
                    Console.Write("Выберите тип животного (1 - Обезьяна, 2 - Кролик, 3 - Тигр, 4 - Волк): ");
                    string? type = Console.ReadLine();
                    int kindness = 0;
                    if (type == "1" || type == "2")
                    {
                        Console.Write("Введите уровень доброты (0-10): ");
                        kindness = int.Parse(Console.ReadLine());
                    }
                    Animal? animal = type switch
                    {
                        "1" => new Monkey { Name = name, Food = food, IsHealthy = isHealthy, Number = new Random().Next(1000, 9999), Kindness = kindness },
                        "2" => new Rabbit { Name = name, Food = food, IsHealthy = isHealthy, Number = new Random().Next(1000, 9999), Kindness = kindness },
                        "3" => new Tiger { Name = name, Food = food, IsHealthy = isHealthy, Number = new Random().Next(1000, 9999) },
                        "4" => new Wolf { Name = name, Food = food, IsHealthy = isHealthy, Number = new Random().Next(1000, 9999) },
                        _ => null
                    };
                    if (animal != null)
                    {
                        zoo?.AddAnimal(animal);
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор животного.");
                    }
                    break;
                case "2":
                    Console.Write("Выберите тип предмета (1 - Стол, 2 - Компьютер): ");
                    string? itemType = Console.ReadLine();
                    Thing? thing = itemType switch
                    {
                        "1" => new Table { Name = "Стол", Number = new Random().Next(1000, 9999) },
                        "2" => new Computer { Name = "Компьютер", Number = new Random().Next(1000, 9999) },
                        _ => null
                    };
                    if (thing != null)
                    {
                        zoo?.AddThing(thing);
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор предмета.");
                    }
                    break;
                case "3":
                    zoo?.ListAnimals();
                    break;
                case "4":
                    zoo?.FoodReport();
                    break;
                case "5":
                    zoo?.ContactZooAnimals();
                    break;
                case "6":
                    zoo?.InventoryReport();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                    break;
            }
        }
    }
}

