using System;
using System.Globalization;


namespace introducao_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
          int idade = 32;
            double saldo = 10.35784;
            string nome = "Maria";
            //primeiro modo de Placeholders
            Console.WriteLine("{0} tem {1} anos e tem saldo igual a {2:F2} reais", nome, idade, saldo);
            //segundo modo de interpolação
            Console.WriteLine($"{nome} tem {idade} anos e tem saldo igual a {saldo:F2} reais");
            //terceiro modo de concatenação
            Console.WriteLine(nome + " tem " + idade + " anos e tem saldo igual a "
            + saldo.ToString("F2", CultureInfo.InvariantCulture) + " reais");
            

            string produto1 = "Computador";
            string produto2 = "Mesa de escritório";
            byte idade2 = 20;
            int codigo = 52;
            char genero = 'M';
            double preco1 = 2100.0;
            double preco2 = 650.58;
            double medida = 53.234567;

            Console.WriteLine("Produtos:" + produto1 + "cujo preço é " +$"{preco1} {produto2}" + " cujo preço é "+ $"{preco2}");
            Console.ReadKey();

        }
    }
}
