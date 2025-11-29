namespace Lab3csharp;

using System;
using System.IO;
using System.Linq;
using System.Text;
//3. Розв’язати задачу з індивідуального завдання 1(б) при умові, що текстовий рядок
//імпортується з деякого наперед створеного файла input.txt, а результати роботи програми
//потрібно записати у новостворений під час виконання проекту файл output.txt.
public class Task3
{
    public static void Exercise3(string[] args)
    {   
        Console.WriteLine($"Exercise 3.");
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        string inputPath = "/home/kiriko/Documents/input";
        string outputPath = "/home/kiriko/Documents/output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Файл {inputPath} не знайдено!");
            return;
        }

        string inputText = File.ReadAllText(inputPath, Encoding.UTF8);

        string[] words = inputText.Split(new char[] { ' ', '\t', ',', '.', '!', '?', ';', ':', '-', '«', '»' },
                                         StringSplitOptions.RemoveEmptyEntries);

        string consonants = "бвгґджзйклмнпрстфхцчшщ";

        var result = words.Where(word =>
        {
            int consonantCount = word.ToLower()
                                     .Count(ch => consonants.Contains(ch));

            return consonantCount % 2 == 0;  // залишаємо слова з парною кількістю приголосних
        });

        File.WriteAllText(outputPath, string.Join(" ", result), Encoding.UTF8);

        Console.WriteLine($"Обробку завершено. Результат записано у файл {outputPath}");
    }
}

