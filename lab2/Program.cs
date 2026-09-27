using System;
using System.Threading;

Console.WriteLine("Hello, Jerry");

Console.WriteLine("\n"); 

Console.WriteLine("Одна функция");

for (int i = 0; i < 3; i++)
{
    PrintLetters();
    
    if (i < 2) 
    {
        Thread.Sleep(500);
    }
}

Console.WriteLine("\n"); 

Console.WriteLine("Три функции");

for (int i = 0; i < 3; i++)
{
    FunctionA(); 
    
    if (i < 2) 
    {
        Thread.Sleep(500);
    }
}

void PrintLetters()
{
    Console.WriteLine("A");
    Console.WriteLine("B");
    Console.WriteLine("C");
}

void FunctionA()
{
    Console.WriteLine("A");
    FunctionB(); 
    FunctionC(); 
}

void FunctionB()
{
    Console.WriteLine("B");
}

void FunctionC()
{
    Console.WriteLine("C");
}