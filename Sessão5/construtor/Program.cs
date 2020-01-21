using System;
using System.Globalization;

namespace construtor
{
    class Program
    {
        static void Main(string[] args)
        {

            Produto p = new Produto("TV", 500.00, 10);
            p.Nome = "T";
            //não deixa alterar o preço > p.Preco = 100.00;
            Console.WriteLine(p.Nome);
            Console.WriteLine(p.Preco);
            /*Console.WriteLine("Entre os dados do produto:");
            Console.Write("Nome: ");
            string Nome = Console.ReadLine();
            Console.Write("Preço: ");
            double Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Produto p = new Produto( nome, preco);
            Produto p2 = new Produto();

            Produto p3 = new Produto {
                Nome = "TV",
                Preco = 500.00,
                Quantidade = 20
            };

            Console.WriteLine();
            Console.WriteLine("Dados do produto: " + p);
            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int qte = int.Parse(Console.ReadLine());
            p.AdicionarProdutos(qte);
            Console.WriteLine();
            Console.WriteLine("Dados atualizados: " + p);
            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            qte = int.Parse(Console.ReadLine());
            p.RemoverProdutos(qte);
            Console.WriteLine();
            Console.WriteLine("Dados atualizados: " + p);
            */
            
        }
    }
}
