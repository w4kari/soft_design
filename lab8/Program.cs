using System;

class Program
{
    static void Main()
    {
        // 1. true в условии заставляет тело if выполняться всегда
        if (true)
        {
            Console.WriteLine("Hello");
        }

        // 2. false в условии дает предупреждение компилятора (unreachable code), код внутри никогда не выполнится
        if (false)
        {
            Console.WriteLine("Hello");
        }

        // 3. при использовании переменных предупреждения компилятора не будет, выведется только Hello
        bool execute = true;
        if (execute)
        {
            Console.WriteLine("Hello");
        }

        bool notExecute = !execute;
        if (notExecute)
        {
            Console.WriteLine("Not executed");
        }

        // 4. f1 и f2 идентичны (если a вернет false, b не вызовется), а в f3 обе функции вызываются заранее до проверки
        F1();
        F2();
        F3();

        // 5. ошибка компиляции: в условии if может быть только тип bool, число int использовать нельзя
        // if (1) { Console.WriteLine("Hello"); }

        // 6. условие ложно, поэтому весь блок в фигурных скобках пропускается и ничего не выводится
        if (false)
        {
            Console.WriteLine("A");
            Console.WriteLine("B");
        }

        // 7. без фигурных скобок к if относится только первая строка (A), поэтому строка B выполнится независимо от условия
        if (false)
            Console.WriteLine("A");
            Console.WriteLine("B");

        // 8. блок else выполняется тогда, когда условие в if оказалось ложным (выведется B)
        if (false)
        {
            Console.WriteLine("A");
        }
        else
        {
            Console.WriteLine("B");
        }

        // 9. условие проверяется один раз в начале, поэтому изменение переменной внутри if не запустит блок else
        bool a9 = true;
        if (a9)
        {
            a9 = false;
        }
        else
        {
            Console.WriteLine("B");
        }

        // 10. return внутри if сразу завершает всю функцию, код в else и после него не выполняется
        ReturnInIf();

        // 11. без скобок к if и else привязывается по одной инструкции: выполнится A, блок else (B) пропустится, затем выполнится C
        if (true)
            Console.WriteLine("A");
        else
            Console.WriteLine("B");
        Console.WriteLine("C");

        // 12. допустимо комбинировать одиночную инструкцию без скобок в if и блок со скобками в else
        if (true)
            Console.WriteLine("A");
        else
        {
            Console.WriteLine("B");
        }

        // 13. цепочка else if позволяет последовательно проверять условия без лишней вложенности
        bool a13 = false, b13 = true, c13 = false;
        if (a13)
        {
            Console.WriteLine("A");
        }
        else if (b13)
        {
            Console.WriteLine("B");
        }
        else if (c13)
        {
            Console.WriteLine("C");
        }

        // 14. паттерн early return (guard clause) избавляет от сложной вложенности else с помощью выхода из функции через return
        EarlyReturnDemo(false, true, false);

        // 15. управление циклом: continue сразу переходит к следующей итерации, а break полностью прерывает цикл
        int i = 0;
        while (true)
        {
            if (i == 4)
            {
                Console.WriteLine("ERROR: Should not happen");
                break;
            }
            if (i == 3)
            {
                Console.WriteLine("Exit");
                break;
            }
            if (i == 0)
            {
                Console.WriteLine("Increase by 2 on first iter");
                i += 2;
                continue;
            }

            Console.WriteLine("Increase by 1 normally");
            i++;
        }

        // 16. return внутри цикла немедленно завершает всю функцию и возвращает 0, игнорируя break и последующий код
        int result16 = ReturnInWhile();
        Console.WriteLine(result16);
    }

    static bool A()
    {
        Console.WriteLine("A");
        return true;
    }

    static bool B()
    {
        Console.WriteLine("B");
        return true;
    }

    static void F1()
    {
        if (A())
        {
            if (B())
            {
                Console.WriteLine("Hello");
            }
        }
    }

    static void F2()
    {
        if (A() && B())
        {
            Console.WriteLine("Hello");
        }
    }

    static void F3()
    {
        // семантическое отличие: функции вызываются всегда, даже если первая вернет false
        bool a = A();
        bool b = B();
        bool ok = a && b;
        if (ok)
        {
            Console.WriteLine("Hello");
        }
    }

    static void ReturnInIf()
    {
        if (true)
        {
            return;
        }
        else
        {
            Console.WriteLine("Else");
        }
        Console.WriteLine("After Else");
    }

    static void EarlyReturnDemo(bool a, bool b, bool c)
    {
        if (a)
        {
            Console.WriteLine("A");
            return;
        }
        Console.WriteLine("After A");

        if (b)
        {
            Console.WriteLine("B");
            return;
        }
        Console.WriteLine("After B");

        if (c)
        {
            Console.WriteLine("C");
            return;
        }
        Console.WriteLine("After C");
    }

    static int ReturnInWhile()
    {
        while (true)
        {
            if (true)
            {
                return 0;
            }
            break;
        }
        return 1;
    }
}