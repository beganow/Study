using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public interface IName
    {
        void Hight();
        void Weight();
        void IQ();
    }
    public abstract class Worker : IName
    {
        public abstract void Hight();
        public abstract void Weight();
        public abstract void IQ();
        public string Name { get; set; }
        public int Birthday { get; set; }
        public int StartDate { get; set; }
    }
    class Person
    {
        public void Hight(Worker worker)
        {
            worker.Hight();
        }
        public void Weight(Worker worker){
            worker.Weight();
        }
        public void IQ(Worker worker)
        {
            worker.IQ();
        }
        public string Name
        {
            get;
            set;
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(Name))
                return base.ToString();
            return Name;
        }
    }
    class Stajor : Worker, IName
    {
        public string Name { get; set; }
        public int Birthday { get; set; }
        public int StartDate { get; set; }
        public virtual void work()
        {
            Console.WriteLine(Name);
        }
        public override void Hight()
        {
            Console.WriteLine("180");
        }
        public override void Weight()
        {
            Console.WriteLine("67");
        }
        public override void IQ()
        {
            Console.WriteLine("50%");
        }
        public Stajor(string name, int bithday, int startday)
        {
            this.Name = name;
            this.Birthday = bithday;
            this.StartDate = startday;

        }
    }
    class Junior  : Worker, IName
    {
        public string Name { get; set; }
        public int Birthday { get; set; }
        public int StartDate { get; set; }
        public virtual void work()
        {
            Console.WriteLine(Birthday);
        }
        public override void Hight()
        {
            Console.WriteLine("160");
        }
        public override void Weight()
        {
            Console.WriteLine("50");
        }
        public override void IQ()
        {
            Console.WriteLine("70%");
        }
        public Junior(string name, int bithday, int startday)
        {
            this.Name = name;
            this.Birthday = bithday;
            this.StartDate = startday;

        }
    }
        class SeniorPomidor : Worker, IName
    {
        public string Name { get; set; }
        public int Birthday { get; set; }
        public int StartDate { get; set; }
        public virtual void work()
        {
            if ((Birthday <30 ) && (Birthday>20))
                Console.WriteLine(  Birthday );
        }
        public override void Hight()
        {
            Console.WriteLine("180");
        }
        public override void Weight()
        {
            Console.WriteLine("67");
        }
        public override void IQ()
        {
            Console.WriteLine("99%");
        }
        public SeniorPomidor(string name, int bithday, int startday)
        {
            this.Name = name;
            this.Birthday = bithday;
            this.StartDate = startday;

        }
    }
        public class List
    {
        public string IamListining(Worker obj)
        {
            if (obj is Stajor c)
            {
                return "Тип объекта: " + c.GetType().Name + "\nНазвание человека: " + c.Name + "\nВес человека: " + c.Birthday + "\nРост человека: " + c.StartDate + "\n" + new String('-', 50);
            }
            if (obj is Junior t)
            {
                return "Тип объекта: " + t.GetType().Name + "\nНазвание человека: " + t.Name + "\nВес человека: " + t.Birthday + "\nРост человека: " + t.StartDate + "\n" + new String('-', 50);
            }
            if (obj is SeniorPomidor b)
            {
                return "Тип объекта: " + b.GetType().Name + "\nНазвание человека: " + b.Name + "\nВес человека: " + b.Birthday + "\nРост человека: " + b.StartDate + "\n" + new String('-', 50);
            }
            return "Ничего нет";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Name = "Pavel" };
            Console.WriteLine(person.ToString());
            Stajor stajor = new Stajor("Nikita", 3, 15);
            Junior junior = new Junior("Olya", 22, 11);
            SeniorPomidor seniorpomidor = new SeniorPomidor("Kate", 26, 18);
            seniorpomidor.work();
            List list= new List();
            Console.WriteLine(list.IamListining(stajor));
            Console.WriteLine(list.IamListining(junior));
            Console.WriteLine(list.IamListining(seniorpomidor));
            Console.WriteLine();
        }
    }
}
