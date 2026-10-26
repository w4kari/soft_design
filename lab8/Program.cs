using System;

class Program
{
    static void Main()
    {
        int num1 = ReadValidNumber();
        int num2 = ReadValidNumber();
        int num3 = ReadValidNumber();

        int product = num1 * num2 * num3;
        Console.WriteLine($"произведение: {product}");
    }

    static int ReadValidNumber()
    {
        while (true)
        {
            Console.Write("введите число больше 2: ");
            string input = Console.ReadLine()!;

            if (!int.TryParse(input, out int number) || number <= 2)
            {
                Console.WriteLine("ошибка! нужно ввести целое число больше 2.");
                continue;
            }

            return number;
        }
    }
}