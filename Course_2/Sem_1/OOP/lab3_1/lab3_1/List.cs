using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_1
{
    class List
    {

        public List<int> a = new List<int>();
        public int Count => a.Count;
        public List() { }
        public void Add(int number)
        {
            a.Add(number);
        }
        public void Remove(int number)
        {
            a.Remove(number);
        }
        public static List operator +(List l1, int number)
        {
            l1.Add(number);
            return l1;
        }
        public static List operator -(List l1, int number)
        {
            int i = 0;
            foreach (var item in l1.a)
            {
                if (item == number)
                {
                      
                    i++;
                 
                }
            }
            if (i == 0)
            {
                Console.WriteLine($"Такого элемента {number} нету в списке ");
            }
            else
            {
                l1.Remove(number);
            }
            return l1;
        }
        public static bool operator !=(List l1, List l2)
        {
            int len;
            if (l2.Count > l1.Count)
            {
                len = l2.Count;
            }
            else
            {
                len = l2.Count;
            }
            int k = 0;
            foreach (var item1 in l1.a)
            {
                foreach (var item2 in l2.a)
                {
                    if (item1 == item2)
                    {
                        k++;
                        break;
                    }
                }
            }
            if (k == len)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(List l1, List l2)
        {
            int len;
            if (l2.Count > l1.Count) { len = l2.Count; }
            else { len = l1.Count; }

            int k = 0;
            foreach (var item1 in l1.a)
            {
                foreach (var item2 in l2.a)
                {
                    if (item1 == item2)
                    {
                        k++;
                        break;
                    }
                }
            }
            if (k == len)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public static bool operator true(List l1)
        {
            int el = int.MinValue;
            foreach (var item1 in l1.a)
            {

                if (el > item1)
                {
                    return false;
                }
                el = item1;

            }
            return true;

        }
        public static bool operator false(List l1)
        {

            int el = int.MinValue;
            foreach (var item1 in l1.a)
            {

                if (el > item1)
                {
                    return false;
                }
                el = item1;

            }
            return true;
        }
        public int Min()
        {
            int min = int.MaxValue;
            foreach (var item in a)
            {
                if (item < min) min = item;
            }
            return min;
        }
        public class Developer
        {
            private string Fio;
            public int id;
            private string department;
            public string ComponyName;
        }
          
    }
}

