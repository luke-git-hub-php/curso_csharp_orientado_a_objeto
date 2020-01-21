using System;
using System.Globalization;

namespace estrutura_while
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Digite um número");
            //double x = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //while (x >= 0.0) {
            //    double raiz = Math.Sqrt(x);
            //    Console.WriteLine(raiz.ToString("F3", CultureInfo.InvariantCulture));
            //    Console.WriteLine("Digite outro número: ");
            //    x = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //}
            //Console.WriteLine("Número negativo");

            //exercicio 1 
            /*int senha = int.Parse(Console.ReadLine());

            while (senha != 2002) {
                Console.WriteLine("Senha invalida");
                senha = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Senha permitida");
            */

            //exercicio 2
            /*int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            while (x != 0 && y != 0)
            {
                if (x > 0 && y > 0)
                {
                    Console.WriteLine("primeiro");
                }
                else if (x < 0 && y > 0)
                {
                    Console.WriteLine("segundo");
                }
                else if (x < 0 && y < 0)
                {
                    Console.WriteLine("terceiro");
                }
                else
                {
                    Console.WriteLine("quarto");
                }
                x = int.Parse(Console.ReadLine());
                y = int.Parse(Console.ReadLine());
            }*/

            //exercicio 3 
            int alcool = 0;
            int gasolina = 0;
            int diesel = 0;

            int tipo = int.Parse(Console.ReadLine());

            while (tipo != 4)
            {
                if (tipo == 1)
                {
                    alcool = alcool + 1;
                }
                else if (tipo == 2)
                {
                    gasolina = gasolina + 1;
                }
                else if (tipo == 3)
                {
                    diesel = diesel + 1;
                }

                tipo = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("MUITO OBRIGADO");
            Console.WriteLine("Alcool: " + alcool);
            Console.WriteLine("Gasolina: " + gasolina);
            Console.WriteLine("Diesel: " + diesel);

        }

    }
}
