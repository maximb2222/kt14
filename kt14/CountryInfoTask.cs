using System;
using System.Collections.Generic;

class CountryInfoTask
{
    public static void Execute()
    {
        var capitals = new Dictionary<string, string>
        {
            { "Россия", "Москва" },
            { "США", "Вашингтон" },
            { "Китай", "Пекин" }
        };

        var populations = new Dictionary<string, int>
        {
            { "Россия", 144500000 },
            { "США", 331000000 },
            { "Китай", 1412000000 }
        };

        Console.Write("Введите название страны: ");
        string country = Console.ReadLine();

        if (capitals.ContainsKey(country))
        {
            Console.WriteLine($"Столица: {capitals[country]}, Население: {populations[country]}");
        }
        else
        {
            Console.WriteLine("Страна не найдена.");
        }
    }
}
