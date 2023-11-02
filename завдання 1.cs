using System;

public class Calculator<T>
{
    // Делегат для додавання
    public delegate T AddDelegate(T a, T b);

    // Делегат для віднімання
    public delegate T SubtractDelegate(T a, T b);

    // Делегат для множення
    public delegate T MultiplyDelegate(T a, T b);

    // Делегат для ділення
    public delegate T DivideDelegate(T a, T b);

    // Додавання
    public AddDelegate Add { get; set; }

    // Віднімання
    public SubtractDelegate Subtract { get; set; }

    // Множення
    public MultiplyDelegate Multiply { get; set; }

    // Ділення
    public DivideDelegate Divide { get; set; }

    public Calculator(AddDelegate add, SubtractDelegate subtract, MultiplyDelegate multiply, DivideDelegate divide)
    {
        Add = add;
        Subtract = subtract;
        Multiply = multiply;
        Divide = divide;
    }

    // Метод для виконання додавання
    public T PerformAddition(T a, T b)
    {
        return Add(a, b);
    }

    // Метод для виконання віднімання
    public T PerformSubtraction(T a, T b)
    {
        return Subtract(a, b);
    }

    // Метод для виконання множення
    public T PerformMultiplication(T a, T b)
    {
        return Multiply(a, b);
    }

    // Метод для виконання ділення
    public T PerformDivision(T a, T b)
    {
        return Divide(a, b);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення калькулятора для цілих чисел
        Calculator<int> intCalculator = new Calculator<int>((a, b) => a + b, (a, b) => a - b, (a, b) => a * b, (a, b) => a / b);

        int num1 = 10;
        int num2 = 5;

        Console.WriteLine("Додавання: " + intCalculator.PerformAddition(num1, num2));
        Console.WriteLine("Віднімання: " + intCalculator.PerformSubtraction(num1, num2));
        Console.WriteLine("Множення: " + intCalculator.PerformMultiplication(num1, num2));
        Console.WriteLine("Ділення: " + intCalculator.PerformDivision(num1, num2));

        // Створення калькулятора для дійсних чисел
        Calculator<double> doubleCalculator = new Calculator<double>((a, b) => a + b, (a, b) => a - b, (a, b) => a * b, (a, b) => a / b);

        double num3 = 10.5;
        double num4 = 2.5;

        Console.WriteLine("Додавання: " + doubleCalculator.PerformAddition(num3, num4));
        Console.WriteLine("Віднімання: " + doubleCalculator.PerformSubtraction(num3, num4));
        Console.WriteLine("Множення: " + doubleCalculator.PerformMultiplication(num3, num4));
        Console.WriteLine("Ділення: " + doubleCalculator.PerformDivision(num3, num4));
    }
}
