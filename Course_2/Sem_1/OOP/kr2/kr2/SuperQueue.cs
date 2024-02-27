using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr2
{
    class Mistake : Exception
    {
        public Mistake()
        {
            Console.WriteLine("Не удалось добавить 4 элемент");
        }
    }
    class SuperQueue<T> where T:new()
    {

        Queue<T> queue = new Queue<T>();
        int i = 0;
        public void Add(T el)
        {
            i++; 
            if (i == 4)
            {
                throw new Mistake();
            }
            queue.Enqueue(el);
           
        }
        public void Print()
        {
            foreach(var item in queue)
            {
                Console.WriteLine(item);
            }
        }
        public SuperQueue()
        {
            
        }
    }
}
