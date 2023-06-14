using System;
using lab3;

class Program
{
    static void Main()
    {
        Console.WriteLine("НОД(667,703): " + Operations.EuclideanAlgorithm(667, 703));
        Console.WriteLine("НОД(12, 56, 369): " + Operations.EuclideanAlgorithm(12, 56, 369));

        Console.WriteLine("Все простые числа от 667 до 703: ");
        foreach (int i in Operations.SieveOfEratosthenes(667, 703))
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("Все простые числа от 2 до 677: ");
        foreach (int i in Operations.SieveOfEratosthenes(2, 667))
        {
            Console.WriteLine(i);
        }
    }
}
