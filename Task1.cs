using System.Linq;
using System.Text.RegularExpressions;
namespace Lab3csharp;
//  1. З клавіатури вводиться текстовий рядок. Розробити консольний застосунок, який реалізує
// вказані дії.
//  7. а) видаляє всі слова, що містять непарну кількість приголосних літер; б) видаляє з тексту всі
// слова-паліндроми
//Exercise1
public class Task1
{
        // Українські голосні
    static readonly char[] vowels = 
        { 'а', 'е', 'є', 'и', 'і', 'ї', 'о', 'у', 'ю', 'я' };

    static bool IsConsonant(char c)
    {
        c = char.ToLower(c);
        return char.IsLetter(c) && !vowels.Contains(c);
    }

    // а) Перевірка на непарну кількість приголосних
    static bool HasOddConsonants(string word)
    {
        int count = word.Count(IsConsonant);
        return count % 2 == 1;
    }

    // б) Перевірка на паліндром
    static bool IsPalindrome(string word)
    {
        string clean = new string(word
            .Where(char.IsLetter)
            .Select(char.ToLower)
            .ToArray());

        return clean.Length > 1 && clean.SequenceEqual(clean.Reverse());
    }

    // Видалення слів з непарною кількістю приголосних
    static string RemoveOddConsonantWords(string text)
    {
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var result = words.Where(w => !HasOddConsonants(w));
        return string.Join(" ", result);
    }

    // Видалення паліндромів
    static string RemovePalindromes(string text)
    {
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var result = words.Where(w => !IsPalindrome(w));
        return string.Join(" ", result);
    }

    public static void Exercise1(string[] args)
    {   
        Console.WriteLine("Exercise 1.");
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        string input = "";
        do
        {
            Console.Write("Введіть текстовий рядок: ");
            input = Console.ReadLine();
        }
        while (string.IsNullOrWhiteSpace(input));

        Console.WriteLine("\n--- Результати обробки ---");

        string noOddConsonants = RemoveOddConsonantWords(input);
        Console.WriteLine("а) Текст без слів із непарною кількістю приголосних:");
        Console.WriteLine(noOddConsonants);

        string noPalindromes = RemovePalindromes(input);
        Console.WriteLine("\nб) Текст без слів-паліндромів:");
        Console.WriteLine(noPalindromes);
    }
}
