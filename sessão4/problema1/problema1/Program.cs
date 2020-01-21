using System;
using System.Globalization;

namespace problema1
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto();
            Console.WriteLine("Entre com os dados do produto");
            Console.WriteLine("Nome: ");
            p.Nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            p.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Quantidade no estoque: ");
            p.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados do Produto: "+ p);

            Console.WriteLine();
            Console.WriteLine("Digite o número de produtos a ser adicionado");
            int qte = int.Parse(Console.ReadLine());
            p.AdicionarProdutos(qte);
            Console.WriteLine("Dados atualizados: "+ p);

            Console.WriteLine();
            Console.WriteLine("Digite o número de produtos a ser removido do estoque");
            qte = int.Parse(Console.ReadLine());
            p.RemoverProdutos(qte);

            Console.WriteLine();
            Console.WriteLine("Dados atualizados: " + p);
        }
    }
}
