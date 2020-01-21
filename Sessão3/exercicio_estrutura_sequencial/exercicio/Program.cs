using System;
using System.Globalization;

namespace exercicio
{
    class Program
    {
        static void Main(string[] args)
        {

            //exercicio1
            //int A, B, soma;

            //A = int.Parse(Console.ReadLine());
            //B = int.Parse(Console.ReadLine());

            //soma = A + B;

            //Console.WriteLine("SOMA = " + soma);*/

            //exercicio2
            /*while (true)
            {
                Console.WriteLine("Digite o valor do raio");
                double pi = 3.14159;
                double raio = double.Parse(Console.ReadLine());
                double area = pi * (raio * raio);
                Console.WriteLine("Área do círculo: " + area.ToString("F4", CultureInfo.InvariantCulture));
                
            }*/
            //exercicio3
            /* int a, b, c, d, result;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());

            result = (a * b - c * d);
            Console.WriteLine(result);
            */
            //exercicio4
            int num_fun, num_hrs_t;
            double vlr_horas, calculo;
            num_fun = int.Parse(Console.ReadLine());
            num_hrs_t = int.Parse(Console.ReadLine());
            vlr_horas = double.Parse(Console.ReadLine());
            calculo = (num_hrs_t * vlr_horas);
            Console.WriteLine("Número do Funcionário: "+ num_fun);
            Console.WriteLine("Salário do funcionário = U$ "+ calculo.ToString("F4", CultureInfo.InvariantCulture));
            Console.ReadKey();
        }
    }
}
