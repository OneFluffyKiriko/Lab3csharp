using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace Lab3csharp;
//2. Створити програми для роз’язування задач згідно свого варіанта.
//Дано файл, елементами якого є окремі символи, що складають слово "олгаритм". Отримати
//новий файл, в якому літери слова "алгоритм" будуть розміщені правильно.

public class Task2
{
    // Цільове слово
    const string TargetWord = "алгоритм";

    public static int Exercise2(string[] args)
    {   
                Console.WriteLine($"Exercise 2.");
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        if (args.Length < 2)
        {
            Console.WriteLine("Використання: app.exe <вхідний_файл> <вихідний_файл>");
            return 1;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Файл не знайдено: {inputPath}");
            return 1;
        }

        string content;
        try
        {
            content = File.ReadAllText(inputPath, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка читання файлу: {ex.Message}");
            return 1;
        }

        // Витягнути лише літери (мінус пробіли, пунктуацію тощо)
        List<char> letters = content.Where(char.IsLetter).Select(char.ToLower).ToList();

        // Підготувати словник лічильників наявних літер
        var counts = new Dictionary<char,int>();
        foreach (var ch in letters)
        {
            if (counts.ContainsKey(ch)) counts[ch]++;
            else counts[ch] = 1;
        }

        // Перевіримо, чи вистачає потрібних літер для слова "алгоритм"
        var missing = new List<char>();
        foreach (char t in TargetWord)
        {
            if (!counts.ContainsKey(t) || counts[t] <= 0)
            {
                missing.Add(t);
            }
            else
            {
                counts[t]--; // зарезервувати одну літеру
            }
        }

        if (missing.Count > 0)
        {
            Console.WriteLine("Вхідний файл не містить достатньо літер для формування слова \"алгоритм\".");
            Console.WriteLine("Не вистачає літер: " + string.Join(", ", missing.Distinct()));
            return 1;
        }

        // Якщо дійшли сюди — можна сформувати слово
        string output = TargetWord;

        try
        {
            File.WriteAllText(outputPath, output, Encoding.UTF8);
            Console.WriteLine($"Успіх: записано слово \"{output}\" у файл {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка запису файлу: {ex.Message}");
            return 1;
        }

        return 0;
    }
}