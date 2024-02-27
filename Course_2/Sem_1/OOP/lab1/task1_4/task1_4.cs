using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class task1_4
    {
        static void Main(string[] args)
        {
            (int, string, char, string, ulong) k = (14, "Human", 'q', "Woman", 45);
            Console.WriteLine(k.Item1 + " " + k.Item2 + " " + k.Item3 + " " + k.Item4 + " " + k.Item5);
            Console.WriteLine(k.Item1 + " " + k.Item3 + " " + k.Item4);
//способ 1 распаковка кортежа
            (int a, string b, char c, string d, ulong e) = k;
            Console.WriteLine(a + ' ' + b + ' ' + c + ' ' + d + ' ' + e);
            //способ 2 распаковка кортежа
            var (z, x, y, m, ep) = k;
            Console.WriteLine(z + ' ' + x + ' ' + y + ' ' + m + ' ' + ep);
            //способ 3 распаковка кортежа
            var p1 = 156;
            var p2 = "erjegjre";
            var p3 = ' ';
            var p4 = string.Empty;
            var p5 = 123.453234;
            (p1, p2, p3, p4, p5) = k;
            Console.WriteLine(p1 + ' ' + p2 + ' ' + p3 + ' ' + p4 + ' ' + p5);
            var _ = (sum: -33, world: "World", a: 'a', mir: "Mir", very: 18446744073709551614);
            Console.WriteLine(_.sum + " " + _.world + " " + _.a + " " + _.mir);
            Console.WriteLine(k == _);
            Console.WriteLine(k != _);
            Console.ReadKey(true);

        }

    }
}
