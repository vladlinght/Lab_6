using System;
using System.Collections.Generic;

public class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

    // Делегат для функції
    public delegate TResult Func<TKey, TResult>(TKey key);

    // Клас для зберігання результату та часу створення
    private class CacheItem
    {
        public TResult Result { get; set; }
        public DateTime CreatedTime { get; set; }
    }

    // Термін дії кешованих результатів в секундах
    private int cacheDurationSeconds;

    public FunctionCache(int cacheDurationSeconds)
    {
        this.cacheDurationSeconds = cacheDurationSeconds;
    }

    // Метод для виконання функції та кешування результату
    public TResult GetOrAdd(TKey key, Func<TKey, TResult> func)
    {
        if (cache.TryGetValue(key, out var cacheItem) && IsCacheValid(cacheItem.CreatedTime))
        {
            return cacheItem.Result;
        }
        else
        {
            TResult result = func(key);
            cache[key] = new CacheItem { Result = result, CreatedTime = DateTime.Now };
            return result;
        }
    }

    // Перевірка часу створення результату
    private bool IsCacheValid(DateTime createdTime)
    {
        return (DateTime.Now - createdTime).TotalSeconds <= cacheDurationSeconds;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення кешу для результатів функцій з терміном дії 10 секунд
        FunctionCache<string, int> cache = new FunctionCache<string, int>(10);

        Func<string, int> expensiveFunction = key =>
        {
            Console.WriteLine($"Обчислення результату для ключа: {key}");
            return key.Length;
        };

        string key1 = "Hello";
        string key2 = "World";

        // Виклик функції через кеш
        int result1 = cache.GetOrAdd(key1, expensiveFunction);
        int result2 = cache.GetOrAdd(key2, expensiveFunction);

        Console.WriteLine($"Результат 1: {result1}");
        Console.WriteLine($"Результат 2: {result2}");

        // Через 5 секунд результат 1 буде кешований, але результат 2 буде перевично обчислено
        System.Threading.Thread.Sleep(5000);

        int result3 = cache.GetOrAdd(key1, expensiveFunction);
        int result4 = cache.GetOrAdd(key2, expensiveFunction);

        Console.WriteLine($"Результат 3: {result3}");
        Console.WriteLine($"Результат 4: {result4}");
    }
}
