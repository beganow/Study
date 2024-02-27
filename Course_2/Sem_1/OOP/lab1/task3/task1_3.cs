using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class task1_3
    {
        static void Main(string[] args)
        {
            int[,] a = new int[,]
            {
                {12,25,36},
                {56,7,25}
            };
            int b, c;
            b = a.GetLength(0);
            c = a.GetLength(1);
            for(int i=0; i < b; i++)
            {
                for (int j=0;j< c; j++)
                {
                    Console.Write(String.Format("{0,3}", a[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            int[] d = new int[] { 3, 2, 4, 7, 37, 42, 89, 32, 18, 34, 2, 7, 34 };
            b = d.GetLength(0);

            Console.WriteLine($"Количество элементов {b}");
            for (int i = 0; i < b; i++)
            {
                Console.WriteLine(d[i] + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Введите индекс элемента:");
            int index= Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите на что изменить");
            int newMass = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < d.Length; i++)
            {
                d[index] = newMass;
            }
            Console.WriteLine("Вывод:");
            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine(d[i]);
            }


            int[][] massiv = new int[3][];
            massiv[0] = new int[5];
            massiv[1] = new int[4];
            massiv[2] = new int[3];
            Random random = new Random();
            for (int i = 0; i < massiv.Length; i++)
            {
                for (int j = 0; j < massiv[i].Length; j++)
                {
                    massiv[i][j] = random.Next(100);
                }
            }
            Console.WriteLine("Вывод:");
            for (int i = 0; i < massiv.Length; i++)
            {
                for (int j = 0; j < massiv[i].Length; j++)
                {
                    Console.Write(massiv[i][j] + " ");
                }
                Console.WriteLine();
            }


            var ab = new[] { 1, 10, 100, 1000 }; // int[]
            var ba = "hello"; // string
            Console.ReadKey(true);

        }
    }
}
