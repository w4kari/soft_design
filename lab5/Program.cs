bool result = A() || B();

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