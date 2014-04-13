using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finds nth number of Fibonacci sequence");
            Console.WriteLine("Enter n:");
            int n = -1;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Invalid input. Enter n:");
            }
            Console.WriteLine(fibonacci(n).ToString());
            Console.ReadLine();
        }

        private static int fibonacci(int n)
        {
            int ret = -1;
            if (n <= 1)
            {
                ret =1;
            }
            else
            {
                ret = fibonacci2(n, 0, 1);
            }
                
            return ret;
        }

        private static int fibonacci2(int current, int last1, int last2)
        {
            if (current == 1) { return last2; }
            current--;
            return fibonacci2(current, last2, last1+last2 );
        }
    }
}
