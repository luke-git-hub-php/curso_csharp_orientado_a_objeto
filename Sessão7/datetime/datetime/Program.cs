using System;
using System.Globalization;

namespace datetime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d1 = new DateTime(2019, 12, 17);
            DateTime d2 = new DateTime(2019, 12, 17, 13,09,58);
            DateTime d3 = new DateTime(2019, 12, 17, 13, 09, 58, 500);

            DateTime d4 = DateTime.Now;
            DateTime d5 = DateTime.Today;
            DateTime d6 = DateTime.UtcNow;

            DateTime d7 = DateTime.ParseExact("2000-12-17","yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime d8 = DateTime.ParseExact("17/12/2019 13:21:58","dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            Console.WriteLine(d1);
            Console.WriteLine(d2);
            Console.WriteLine(d3);
            Console.WriteLine(d4);
            Console.WriteLine(d5);
            Console.WriteLine(d6);
            Console.WriteLine(d7);
            Console.WriteLine(d8);
            /*DateTime d1 = DateTime.Now;
            Console.WriteLine(d1);
            Console.WriteLine(d1.Ticks);*/
        }
    }
}
