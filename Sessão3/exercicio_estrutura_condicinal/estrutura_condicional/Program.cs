using System;
using System.Globalization;

namespace estrutura_condicional
{
    class Program
    {
        static void Main(string[] args)
        {
            //exercicio 1
            //int n1;
            //n1 = int.Parse(Console.ReadLine());

            //if (n1 < 0)
            //    Console.WriteLine("Negativo");
            //else
            //    Console.WriteLine("Positivo");

            //exercicio 2
            //int num;
            //num = int.Parse(Console.ReadLine());

            //if(num % 2 == 0)
            //    Console.WriteLine("Número Par");
            //else
            //    Console.WriteLine("Número ímpar");

            //exercicio 3
            //int num1, num2;
            //string[] valores = Console.ReadLine().Split(' ');
            //num1 = int.Parse(valores[0]);
            //num2 = int.Parse(valores[1]);

            //if (num1 % num2 == 0 || num2 % num1 == 0)
            //    Console.WriteLine("São Múltiplos");
            //else
            //    Console.WriteLine("Não são Múltiplos");

            //exercicio 4

                string[] valores = Console.ReadLine().Split(' ');
                int horaInicial = int.Parse(valores[0]);
                int horaFinal = int.Parse(valores[1]);

                int duracao;
                if (horaInicial < horaFinal)
                {
                    duracao = horaFinal - horaInicial;
                }
                else
                {
                    duracao = 24 - horaInicial + horaFinal;
                }

                Console.WriteLine("O JOGO DUROU " + duracao + " HORA(S)");

            }
    }
}
