using System;
using System.Collections.Generic;

public class Repository<T>
{
    private List<T> items = new List<T>();

    // Делегат для критерію
    public delegate bool Criteria<T>(T item);

    // Додати елемент до репозиторію
    public void Add(T item)
    {
        items.Add(item);
    }

    // Знайти всі елементи, які задовольняють критерію
    public List<T> Find(Criteria<T> criteria)
    {
        List<T> result = new List<T>();
        foreach (T item in items)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення репозиторію для рядків
        Repository<string> stringRepository = new Repository<string>();

        stringRepository.Add("Apple");
        stringRepository.Add("Banana");
        stringRepository.Add("Cherry");
        stringRepository.Add("Date");

        // Створення критерію для пошуку рядків, які починаються з "A"
        Repository<string>.Criteria<string> startsWithACriteria = s => s.StartsWith("A");

        List<string> startsWithA = stringRepository.Find(startsWithACriteria);

        Console.WriteLine("Елементи, які починаються з 'A':");
        foreach (string item in startsWithA)
        {
            Console.WriteLine(item);
        }

        // Створення репозиторію для цілих чисел
        Repository<int> intRepository = new Repository<int>();

        intRepository.Add(10);
        intRepository.Add(20);
        intRepository.Add(30);
        intRepository.Add(40);

        // Створення критерію для пошуку парних чисел
        Repository<int>.Criteria<int> evenNumberCriteria = n => n % 2 == 0;

        List<int> evenNumbers = intRepository.Find(evenNumberCriteria);

        Console.WriteLine("Парні числа:");
        foreach (int item in evenNumbers)
        {
            Console.WriteLine(item);
        }
    }
}
