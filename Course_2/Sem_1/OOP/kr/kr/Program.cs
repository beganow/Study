using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            Console.WriteLine("Введите строку:");
            s = Console.ReadLine();

            string[] subs = s.Split();

            foreach (string sub in subs)
            {
                Console.WriteLine($"Substring: {sub}");
            }
            int n = 4;
            int[,] a = new int[n, n];
            int[,] b = new int[n, n]; //массив для сортировки по строкам
            int[,] c = new int[n, n]; //массив для сортировки по столбцам

            Random ran = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = ran.Next(-1, 5);
                    b[i, j] = a[i, j];
                    c[i, j] = a[i, j];
                    Console.Write("{0}\t", a[i, j]);
                }
                Console.WriteLine();
            }
            int[] temp = new int[n];

            Console.WriteLine("\nСортировка по строкам: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    temp[j] = b[i, j];
                Array.Sort(temp);
                for (int k = 0; k < n; k++)
                {
                    b[i, k] = temp[k];
                    Console.Write("{0}\t", b[i, k]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nСортировка по столбцам: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    temp[j] = c[j, i];
                Array.Sort(temp);
                for (int k = 0; k < n; k++)
                    c[k, i] = temp[k];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0}\t", c[i, j]);
                Console.WriteLine();
            }
        }
    }
}
