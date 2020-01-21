using System;
using System.Globalization;

namespace curso {
    class Program {
        static void Main(string[] args) {

            double a, b, c, delta, x1, x2;

            string[] vet = Console.ReadLine().Split(' ');

            a = double.Parse(vet[0], CultureInfo.InvariantCulture);
            b = double.Parse(vet[1], CultureInfo.InvariantCulture);
            c = double.Parse(vet[2], CultureInfo.InvariantCulture);

            delta = b * b - 4 * a * c;

            if (a == 0.0 || delta < 0.0) {
                Console.WriteLine("IMPOSSIVEL CALCULAR");
            }
            else {
                x1 = (-b + Math.Sqrt(delta)) / (2.0 * a);
                x2 = (-b - Math.Sqrt(delta)) / (2.0 * a);
                Console.WriteLine("X1 = " + x1.ToString("F4", CultureInfo.InvariantCulture));
                Console.WriteLine("X2 = " + x2.ToString("F4", CultureInfo.InvariantCulture));
            }

            Console.ReadLine();
        }
    }
}
