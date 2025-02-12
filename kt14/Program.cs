using System;

class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите задание(1-3):");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                WordFrequencyTask.Execute();
                break;
            case "2":
                ExpressionCalculatorTask.Execute();
                break;
            case "3":
                CountryInfoTask.Execute();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }
}
