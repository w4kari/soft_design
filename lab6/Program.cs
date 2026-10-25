using System;

class Program
{
    static void Main()
    {
        // 1. тип bool принимает только true или false и при выводе преобразуется в текст
        bool a1 = true;
        Console.WriteLine(a1);

        // 2. ошибка компиляции: bool — это тип-значение, он не может содержать null
        // bool a2 = null;

        // 3. оператор == сравнивает два выражения и возвращает false
        bool a3 = 1 == 2;
        Console.WriteLine(a3);

        // 4. оператор сравнивает значения, хранящиеся внутри переменных (3 и 4)
        int x4 = 3;
        int y4 = 4;
        bool b4 = x4 == y4;
        Console.WriteLine(b4);

        // 5. сначала вычисляются математические части ((x * 2) и (y + 4)), а затем они сравниваются
        int x5 = 3;
        int y5 = 4;
        bool b5 = x5 * 2 == y5 + 4;
        Console.WriteLine(b5);

        // 6. переменная сначала получает false, а затем перезаписывается значением true
        bool a6 = 1 > 2;
        a6 = 3 == 3;
        Console.WriteLine(a6);

        // 7. передача значения bool переменной в качестве аргумента функции
        bool a7 = true;
        PrintBool(a7);

        // 8. выражение 5 > 3 вычисляется до вызова функции, и внутрь передается результат true
        PrintBool(5 > 3);

        // 9. функция возвращает логическое значение true, которое сохраняется в переменную
        bool result9 = GetTrue();
        Console.WriteLine(result9);

        // 10. функция вычисляет выражение a > b и возвращает результат сравнения (true)
        bool result10 = IsGreater(5, 3);
        Console.WriteLine(result10);

        // 11. оператор == сравнивает два логических значения (true == false дает false)
        bool a11 = true;
        bool b11 = false;
        bool c11 = a11 == b11;
        Console.WriteLine(c11);

        // 12. оператор ! инвертирует значение: делает из false значение true (и наоборот)
        bool a12 = false;
        bool b12 = !a12;
        Console.WriteLine(b12);

        // 13. оператор && возвращает true только если оба операнда равны true, иначе false
        bool a13 = true;
        bool b13 = false;
        bool c13 = a13 && b13;
        Console.WriteLine(c13);

        // 14. первая функция возвращает true, поэтому вызывается и вторая (выведется A и B)
        bool result14 = TrueA() && TrueB();

        // 15. первая функция возвращает true, вторая вызывается и возвращает false (выведется A и B, итог false)
        bool result15 = TrueA() && FalseB();

        // 16. ленивое вычисление (lazy evaluation) для &&: первая функция вернула false, поэтому вторая даже не вызывается (выведется только A)
        bool result16 = FalseA() && TrueB();

        // 17. ленивое вычисление для ||: первая функция вернула true, этого достаточно для истинности, вторая не вызывается (выведется только A)
        bool result17 = TrueA() || TrueB();
    }

    static void PrintBool(bool flag)
    {
        Console.WriteLine(flag);
    }

    static bool GetTrue()
    {
        return true;
    }

    static bool IsGreater(int a, int b)
    {
        return a > b;
    }

    static bool TrueA()
    {
        Console.WriteLine("A");
        return true;
    }

    static bool FalseA()
    {
        Console.WriteLine("A");
        return false;
    }

    static bool TrueB()
    {
        Console.WriteLine("B");
        return true;
    }

    static bool FalseB()
    {
        Console.WriteLine("B");
        return false;
    }
}