using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Stajor
    { public int Detro;
        public string Name { get; set; }
        public int Birthday { get { return Detro; } set { if (value < 18)
                    Console.WriteLine("Меньше 18");
                else
                {
                    Detro = value;
                };
            } }
        public int StartDate { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public override string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public Stajor(string name, int birthday, int startday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.StartDate = startday;
        }
        public Stajor()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stajor stajor = new Stajor();
            stajor.Name = "Pavel";
            stajor.Birthday = 12;
            stajor.StartDate = 2005;
            int Diff = Operation.work(stajor);
            Console.WriteLine(stajor.Name+' '+ stajor.Birthday + " " +stajor.StartDate);
        }
    }
}
