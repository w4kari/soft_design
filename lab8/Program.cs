using System;

struct A
{
    public int f1;
    public int f2;
}

struct Position
{
    public int X;
    public int Y;
}

class Program
{
    static void Main()
    {
        // 1. парсинг через int.Parse: если ввести не число, программа упадет с ошибкой (FormatException)
        string a1 = Console.ReadLine()!;
        int b1 = int.Parse(a1);
        Console.WriteLine(b1);

        // 2. парсинг через int.TryParse: если ввести не число, ошибки не будет — метод вернет false, а в b2 запишется 0
        string a2 = Console.ReadLine()!;
        int b2;
        bool success = int.TryParse(a2, out b2);
        Console.WriteLine(success);
        Console.WriteLine(b2);

        // 3. в функцию передается копия значения переменной, поэтому изменение внутри функции не влияет на исходную переменную (выведется 0)
        int a3 = 0;
        PassByValue(a3);
        Console.WriteLine(a3);

        // 4. ключевое слово out передает ссылку (адрес в памяти) на переменную, функция записывает туда 1 (выведется 1)
        int a4 = 0;
        PassOut(out a4);
        Console.WriteLine(a4);

        // 5. совпадение имен не играет роли, переменные независимы, работа идет через ссылку (выведется 1)
        int a5 = 0;
        PassOutSameName(out a5);
        Console.WriteLine(a5);

        // 6. ошибка компиляции: типы не совпадают, функция ждет ссылку на int, а передается структура A
        // A a6;
        // PassOut(out a6);

        // 7. ошибка компиляции: та же проблема с несовпадением типов, одинаковое имя переменной не помогает
        // A a7;
        // PassOutSameName(out a7);

        // 8. ошибка компиляции: внутри функции переменной типа структуры A пытаются присвоить обычное число int
        // A a8;
        // InvalidStructAssign(out a8);

        // 9. ошибка компиляции: при использовании out функция обязана полностью проинициализировать все поля структуры до своего завершения
        // A a9;
        // IncompleteStructInit(out a9);

        // 10. все поля структуры инициализированы по отдельности внутри функции (выведется 1 и 2)
        A a10;
        InitStructFields(out a10);
        Console.WriteLine(a10.f1);
        Console.WriteLine(a10.f2);

        // 11. вся структура инициализируется целиком через создание нового экземпляра new() (выведется 1 и 2)
        A a11;
        InitWholeStruct(out a11);
        Console.WriteLine(a11.f1);
        Console.WriteLine(a11.f2);

        // 12. функция меняет a12 на 1 через out, а возвращаемое через return значение (2) просто игнорируется (выведется 1)
        int a12 = 0;
        OutWithReturn(out a12);
        Console.WriteLine(a12);

        // 13. функция записывает 1 в a13 через out и возвращает 2 через return, которое сохраняется в b13 (выведется 1 и 2)
        int a13 = 0;
        int b13 = OutWithReturn(out a13);
        Console.WriteLine(a13);
        Console.WriteLine(b13);

        // 14. функция может принимать и инициализировать сразу несколько out параметров (выведется 1 и 2)
        int a14;
        int b14;
        MultipleOut(out a14, out b14);
        Console.WriteLine(a14);
        Console.WriteLine(b14);

        // 15. в качестве out параметра можно передать ссылку на отдельное поле структуры, в p.X запишется 2
        Position p = new() { X = 0, Y = 1 };
        ModifyField(out p.X);
        Console.WriteLine(p.X);

        // практика: ввод 3 чисел больше 2 с валидацией в бесконечном цикле и вывод их произведения
        int num1 = ReadValidNumber();
        int num2 = ReadValidNumber();
        int num3 = ReadValidNumber();
        int product = num1 * num2 * num3;
        Console.WriteLine(product);
    }

    static void PassByValue(int a)
    {
        a = 1;
    }

    static void PassOut(out int b)
    {
        b = 1;
    }

    static void PassOutSameName(out int a)
    {
        a = 1;
    }

    // к пункту 8: ошибка компиляции (нельзя присвоить int в struct A)
    // static void InvalidStructAssign(out A b) { b = 1; }

    // к пункту 9: ошибка компиляции (поле f2 осталось неинициализированным)
    // static void IncompleteStructInit(out A b) { b.f1 = 1; }

    static void InitStructFields(out A b)
    {
        b.f1 = 1;
        b.f2 = 2;
    }

    static void InitWholeStruct(out A b)
    {
        b = new()
        {
            f1 = 1,
            f2 = 2,
        };
    }

    static int OutWithReturn(out int c)
    {
        c = 1;
        return 2;
    }

    static void MultipleOut(out int c, out int d)
    {
        c = 1;
        d = 2;
    }

    static void ModifyField(out int a)
    {
        a = 2;
    }

    // функция для практики: запрашивает ввод в бесконечном цикле, пока не получит число строго больше 2
    static int ReadValidNumber()
    {
        while (true)
        {
            string input = Console.ReadLine()!;

            // если введено не число или число <= 2, переходим на новую итерацию цикла через continue
            if (!int.TryParse(input, out int number) || number <= 2)
            {
                continue;
            }

            // если проверка пройдена, выходим из функции и возвращаем корректное число
            return number;
        }
    }
}