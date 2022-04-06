using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemos
{
    class LinqDemo
    {
        static void Main()
        {
            int[] num = new int[] { 1, 2, 3, 4, 5, 6 };
            // LINQ
            var list = (from x in num
                        select x);
            foreach(var temp in list)
                Console.WriteLine(temp);

            var sum = (from x in num
                       select x).Sum();

            Console.WriteLine("Sum is " + sum);

            var avg = (from x in num
                       select x).Average();
            Console.WriteLine("Avg is  " + avg);

            var evenlist = (from x in num
                        where x % 2 == 0
                        select x);

            Console.WriteLine("Even Nums");
            foreach(var temp in evenlist)
                Console.WriteLine(temp);

            List<string> names = new List<string>()
            {
                 "Ajay Kumar", "Deepak Sahni", "Arun Kumar" };

            var nameslist = (from x in names

                             select x);

            foreach(string temp in nameslist)
                Console.WriteLine(temp);

            var kumarlist = (from x in names
                             where x.Contains("Kumar")
                             select x);
            Console.WriteLine("List of kumars");
            foreach (string temp in kumarlist)
                Console.WriteLine(temp);

        }
    }
}
