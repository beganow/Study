using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr2
{            
    public delegate int Change( int p1 );
  

    class Program
    {       
        static public int Changesize( int p1)
            {
            return p1 / 2;
             }
       static public event Change move;
        static void Main(string[] args)
        {
            Change change = new Change(Changesize);
            move += change;
            Window win1 = new Window(1000, 1000);
            Window win2 = new Window(200, 200);

            User user = new User();
            user.Add(win1);
            user.Add(win2);
            user.NewChange(move);
            user.Print();

            SuperQueue<int> q = new SuperQueue<int>();
            q.Add(33);
            q.Add(3);
            q.Add(99);
            q.Add(101);
            q.Print();
            DateTime dateTime = new DateTime();
            Console.WriteLine(dateTime);
            Console.WriteLine(DateTime.MinValue);
            DateTime date1 = new DateTime(2022, 12, 08, 18, 30, 0);
            Console.WriteLine(date1);    
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Today);
            DateTime date2= new DateTime(2015, 7, 20, 18, 30, 25); 
            Console.WriteLine(date1.AddHours(3));
            DateTime date3 = new DateTime(2015, 7, 20, 18, 30, 25); 
            Console.WriteLine(date1.AddHours(-3));
            Console.WriteLine(date1.ToLongDateString());

            string[] str = new string[] { "timur", "abc", "ewfhwfe", "dwgwda", "aehhef", "bfehefhs" };
            var qver = from item in str.Take(3)
                       orderby item.Length
                       select item;
            var qver1 = from item in str.Skip(3)
                        orderby item
                    select item;
            foreach(var item in qver)
            {
                Console.WriteLine(item);
            }
            foreach (var item in qver1)
            {
                Console.WriteLine(item);
            }






            Console.ReadKey(true);
        }
    }
}
