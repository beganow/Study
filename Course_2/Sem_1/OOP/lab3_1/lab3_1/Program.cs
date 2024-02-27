using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List l1 = new List();
            List l2 = new List();
            
            l1 = l1 + 2;
            l1 = l1 + 3;
            l1 = l1 + 14;
            l1 = l1 + 228;
            l1 = l1 + 16;
            l1 = l1 + 15;
            l1 = l1 - 15;
            l2 = l2 + 1;
            l2 = l2 + 0;
            l2 = l2 + 0;
            l2 = l2 + 555;
            Console.WriteLine("Список 1:");
            foreach (var item in l1.a)
            {
                Console.WriteLine(item);
            } 
            l1 = l1 - 200; 
            Console.WriteLine("Список 2:");
            foreach (var item in l2.a)
            {
                Console.WriteLine(item);
            }
            
            bool b;
            b = l1 != l2;
            Console.WriteLine($"Равен ли первый список второму списку {b}");
            if (l1)
                Console.WriteLine("Список l1 упорядочен ");
            else
            {
                Console.WriteLine("Список l1 не упорядочен");
            }
            int min = l2.Min();
            Console.WriteLine($"Минимальное значение второго списка {min}");
            List.Developer product = new List.Developer() {id=2, ComponyName = "IBM" };
            Console.WriteLine($"ID Разработчика {product.id}, Название компании {product.ComponyName}");
            Console.WriteLine("Работа со статическими классами:");
            Console.WriteLine($"Операция разницы второго списка: { StatisticOperation.Diff(l2)}");
            Console.WriteLine($"Операция суммы второго списка: {StatisticOperation.Sum(l2)}");
            Console.WriteLine($"Операция количества второго списка: {StatisticOperation.CountEl(l2)}");
            Console.WriteLine("Методы расширения: ");
            string str = "ISIT BGTU";
            char c = 'I';
            Console.WriteLine($"Количество элеметов {c} является: { str.CharCount(c)}");
            int a = StatisticOperation.Minimum(l1);
            Console.WriteLine($"Минимальное значение первого списка {a}");
            int zero = l2.Iszero();
            Console.WriteLine($"Количество нулевых элементов во втором списке: {zero}");
            string s = "Бгту лучший университет для программистов ";
            Console.WriteLine($"Количество слов {s.CountWord()} в строке {s}");
        }
    }
}
