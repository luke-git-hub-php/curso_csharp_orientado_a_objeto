using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace construtor
{
    class Produto
    {
        //Atributos privados
        private string _nome;
        //Propriedades autoimplementadas
        public double Preco { get; private set; }
        public int Quantidade { get; private set; }

        //Construtores
        public Produto(){
        }
        public Produto(string nome, double preco, int quantidade)
        {
            _nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
       
        //Properties
        //Propriedades customizadas
        public string Nome
        {
            get { return _nome; }
            set
            {
               if (value != null && value.Length > 1)
                    _nome = value;
            }
        }
        //Outros métados da classe
        public double ValorTotalEmEstoque()
        {
            return Preco * Quantidade;
        }
        public void AdicionarProdutos(int quantidade)
        {
            Quantidade += quantidade;
        }
        public void RemoverProdutos(int quantidade)
        {
            Quantidade -= quantidade;
        }
        public override string ToString()
        {
            return _nome
            + ", $ "
            + Preco.ToString("F2", CultureInfo.InvariantCulture)
            + ", "
            + Quantidade
            + " unidades, Total: $ "
            + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
