using System;

namespace Propriedade_operacoes_TimeSapn
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan t = new TimeSpan(3, 3, 5, 7, 11);
            Console.WriteLine(t);
            Console.WriteLine("Dias: " + t.Days);

            TimeSpan t1 = new TimeSpan(1, 30, 10);
            TimeSpan t2 = new TimeSpan(0, 10, 5);

            TimeSpan sum = t1.Add(t2);
            TimeSpan dif = t1.Subtract(t2);
            TimeSpan mult = t2.Multiply(2.0);
            TimeSpan div = t2.Divide(2.0);

            Console.WriteLine(sum);
            Console.WriteLine(dif);
            Console.WriteLine(mult);
            Console.WriteLine(div);
        }
    }
}
