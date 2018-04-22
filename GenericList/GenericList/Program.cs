using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[4] { 1, 2, 3, 4 };
            int[] b = new int[4];

            int index = 0;

            a.CopyTo(b, index);
            foreach (int elements in a)
                Console.WriteLine(elements);
            Console.ReadLine();
        }
    }
}
