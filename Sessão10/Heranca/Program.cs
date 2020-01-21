using System;
using Heranca.Entities;
namespace Heranca
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessAccount account = new BusinessAccount(8010, "Bob Brow", 100.0, 500.0);
            Console.WriteLine(account.Balance);
            //account.Balance = 200.0;
        }
    }
}
