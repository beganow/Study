using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    class task1_6
    {
        static void Main(string[] args)
        {
            fun1();
            fun2();
            Console.ReadKey(true);
        }
        public static void fun1()
        {
            int a = int.MaxValue;
            try
            {
                checked
                {
                    Console.WriteLine(a+1);
                }
            }
            catch(OverflowException)
            {
                Console.WriteLine("Переполнение");
            }
        }
        public static void fun2()
        {
            int a = int.MaxValue;
            try
            {
                unchecked
                {
                    Console.WriteLine(a + 1);
                }
            }
            catch (OverflowException)
            {

                Console.WriteLine("Переполнение");
            }
            }
    }
}
