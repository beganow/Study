using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr2
{
    class User
    {
        List<Window> list = new List<Window>();

        
        public void Add (Window window)
        {
            list.Add(window);
        }
        public void Print()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.hight+ " " +item.weight);
            }
        }
        public void NewChange(Change newwin)
        {
            foreach(var item in list)
            {
                item.hight=newwin(item.hight);
                item.weight = newwin(item.weight);

            }
        }
    }
}
