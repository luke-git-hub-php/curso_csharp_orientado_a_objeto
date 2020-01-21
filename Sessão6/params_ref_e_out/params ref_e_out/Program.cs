using System;

namespace params_ref_e_out
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 30;
            int triple;
            Calculator.Triple(a, out triple);
            Console.WriteLine(triple);
        }
    }
}
