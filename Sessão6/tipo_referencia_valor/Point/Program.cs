using System;

namespace Point
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Point p;
            p = new Point();
            Console.WriteLine(p);
            */
            //Nullable<double> x = null;
            double? x = null;
            double? y = 10.0;
            Console.WriteLine(x.GetValueOrDefault());
            Console.WriteLine(y.GetValueOrDefault());

            Console.WriteLine(x.HasValue);
            Console.WriteLine(y.HasValue);

            if(x.HasValue)
            Console.WriteLine(x.Value);
            else
            Console.WriteLine("x is null");

            if (y.HasValue)
                Console.WriteLine(y.Value);
            else
                Console.WriteLine("Y is null");
            
            //operador de coalescência nula
            double? c = null;
            double? d = 10;

            double a = c ?? 5;
            double b = d ?? 5;
            Console.WriteLine(a);
            Console.WriteLine(b);
        }

    }
}
