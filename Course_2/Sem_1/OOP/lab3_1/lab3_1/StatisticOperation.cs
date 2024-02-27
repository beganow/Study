using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_1
{
    static class StatisticOperation
    {
        static public int Sum(List list)
        {
            int sum = 0;
            foreach (int item in list.a)
            {
                sum += item;
            }
            return sum;
        }
        static public int Diff(List list)
        {
            int maxValue = 0;
            int minValue = 999;
            foreach (int item in list.a)
            {
                if (item > maxValue)
                {
                    maxValue = item;
                }
                if (item < minValue)
                {
                    minValue = item;
                }
            }
            maxValue -= minValue;
            return maxValue;
        }
        static public int CountEl(List list)
        {
            int count = 0;
            foreach (var item in list.a)
            {
                count++;
            }
            return count;
        }
        static public int CharCount(this string str, char c)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    count++;
                }
            }
            return count;
        }
        static public int Minimum(this List l1)
        {
            int min = int.MaxValue;
            foreach (var item in l1.a)
            {
                if (item < min) min = item;
            }
            return min;
        }
        public static int Iszero(this List list)
        {
            int i = 0;
            foreach (var item in list.a)
            {
                if (item == 0)
                {
                    i++;


                }
            }
            if (i == 0)
                Console.WriteLine("Список 2 не содержит нулей");
            else
            {
                Console.WriteLine("Нулевые элементы есть");
            }
            return i;
        }
        static public int CountWord(this string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if ((i < (s.Length - 1)))
                {
                    if ((s[i] == ' ') && (s[i + 1] != ' '))
                        count++;
                }
            }
            return ++count;
        }
    }
}
