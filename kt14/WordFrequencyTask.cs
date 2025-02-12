using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class WordFrequencyTask
{
    public static void Execute()
    {
        string filePath = "text.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл text.txt не найден. Убедитесь, что файл находится в папке с программой.");
            return;
        }

        string text = File.ReadAllText(filePath);
        var words = text.Split(new[] { ' ', '.', ',', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        var wordCounts = new Dictionary<string, int>();

        foreach (var word in words)
        {
            wordCounts[word] = wordCounts.ContainsKey(word) ? wordCounts[word] + 1 : 1;
        }

        foreach (var kvp in wordCounts.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
