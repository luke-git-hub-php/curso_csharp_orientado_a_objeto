using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>{ };
            //List<string> list2 = new List<string> {"Maria", "Alex" };
            list.Add("Maria");
            list.Add("Alex");
            list.Add("Bob");
            list.Add("Ana");
            list.Insert(2, "Marco");

            foreach (string obj in list) {
                Console.WriteLine(obj);
            }
            Console.WriteLine("List count: " +list.Count);

            string s1 = list.Find(x => x[0] == 'A');
            Console.WriteLine("First 'A':" + s1);

            string s2 = list.FindLast(x => x[0] == 'A');
            Console.WriteLine("Last 'A': " + s2);

            int pos1 = list.FindIndex(x => x[0] == 'A');
            Console.WriteLine("First position 'A': " + pos1);

            int pos2 = list.FindIndex(x => x[0] == 'A');
            Console.WriteLine("Last position 'A': " + pos2);

            List<string> list2 = list.FindAll(x => x.Length == 5);
            Console.WriteLine("-----------");
            foreach(string obg in list2)
            {
                Console.WriteLine(obg);
            }

            list.Remove("Alex");
            Console.WriteLine("--------------");
            foreach (string obg in list)
            {
                Console.WriteLine(obg);
            }

            list.RemoveAll(x => x[0] == 'M');
            Console.WriteLine("--------------");
            foreach (string obg in list)
            {
                Console.WriteLine(obg);
            }
        }
        
    }
}
