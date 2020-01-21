using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int A, B, soma;

            A = int.Parse(Console.ReadLine());
            B = int.Parse(Console.ReadLine());

            soma = A + B;

            Console.WriteLine("SOMA = " + soma);
            Console.ReadKey();
        }
    }
}
