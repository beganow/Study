using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class task1_5
    {
        static void Main(string[] args)
        {
            int[] a = new int[3];
            string str;
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < 3; i++)
            {
                a[i] = Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine("Введите строку");
            str = Console.ReadLine();
            (int, int, int, char) k = fun(a, str);
            Console.WriteLine(k.Item1 + " " + k.Item2 + " " + k.Item3 + " " + k.Item4);
            Console.ReadKey(true);

        }
        public static (int, int, int, char) fun(int[] mass, string s)
        {
            int max, min, sum;
            char first;
            max = mass.Max();
            min = mass.Min();
            sum = mass.Sum();
            first = s[0];
            return (max, min, sum, first);
        }
    }
}
