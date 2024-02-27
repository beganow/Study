using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{  public delegate string Made();
    interface IWork
    {
        string Patronymic { get; set; }
        event Made MadeEvent;
        int this[int index]
        {
            get;
            set;
        }
        void Add();
    }
    class Worker
    {
        public const string proffesion = "proger";
        private const string experience_year = "Five";
        protected const int age = 20;

        public int salary;
        private int vacation;
        protected int h_work;

        public string Name { get; set; }
        private string Surname { get; set; }
        protected string ID_Worker { get; set; }

        public Worker() { }
        public Worker(Worker previousWorker)
        {
            this.Name = previousWorker.Name;
            this.Surname = previousWorker.Surname;
            this.ID_Worker = previousWorker.ID_Worker;
            this.salary = previousWorker.salary;
            this.vacation = previousWorker.vacation;
            this.h_work = previousWorker.h_work;
        }
        public Worker(string Name, string Surname, string ID_Worker, int salary, int vacation, int h_work)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.ID_Worker = ID_Worker;
            this.salary = salary;
            this.vacation = vacation;
            this.h_work = h_work;
        }
        public void Print()
        {
            Console.WriteLine(Name + " " + Surname + " " + ID_Worker+ " " + salary+" "+ vacation+" "+ h_work);
        }
        protected void Add()
        {
            salary++;
            vacation++;
            h_work++;

        }
        private void Delete()
        {
            salary--;
            vacation--;
            h_work--;
        }
    }
    class WorkerNew : IWork
    {
        public const string proffesion = "cassier";
        private const string experience_year = "Feven";
        protected const int age = 44;
        public int salary;
        private int vacation;
        protected int h_work;
        public event Made MadeEvent;

        public string Name { get; set; }
        private string Surname { get; set; }
        protected string ID_Worker { get; set; }
        public string Patronymic { get; set; }
        public int this[int index] { get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        public WorkerNew() { }
        public WorkerNew(WorkerNew previousWorker)
        {
            this.Name = previousWorker.Name;
            this.Surname = previousWorker.Surname;
            this.ID_Worker = previousWorker.ID_Worker;
            this.salary = previousWorker.salary;
            this.vacation = previousWorker.vacation;
            this.h_work = previousWorker.h_work;
        }
        public WorkerNew(string Name, string Surname, string ID_Worker, int salary, int vacation, int h_work)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.ID_Worker = ID_Worker;
            this.salary = salary;
            this.vacation = vacation;
            this.h_work = h_work;
        }
        public void Print()
        {
            Console.WriteLine(Name + " " + Surname + " " + ID_Worker + " " + salary + " " + vacation + " " + h_work);
        }
        public void Add()
        {
            salary+=50;
            vacation++;
            h_work+=5;

        }
        private void Delete()
        {
            salary-=50;
            vacation--;
            h_work-=50;
        }
    }
    class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Human(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }
        public void Exist()
        {
            if (Surname == Name)
            {
                Surname = "none";
            }
        }
    }
    class ItWorker : Human, IWork
    {
        public int worker_id;
        public int this[int index] { get { return worker_id; } set { worker_id = value; } }
        public string Patronymic { get; set; }
        public event Made MadeEvent;
        public ItWorker(string Name, string Surname, string Patronymic) : base(Name, Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
        }
        public void Add()
        {
            Patronymic += "added";
        }

    }

    class Program
    { 
        public static string EventZ() =>"Event lucky";
        static void Main(string[] args)
        {
           
            Worker h1= new Worker();
            Worker h2 = new Worker("Gaus", "Rich", "1111", 2000, 30, 300);
            Worker h3 = new Worker(h2);
            WorkerNew hnew = new WorkerNew("Pavel", "Korolev", "2222", 5000, 12, 150);
            h2.Print();
            
            hnew.MadeEvent += EventZ;
            Console.WriteLine( EventZ() ); 
            Console.WriteLine(hnew[1]);
            ItWorker h5 = new ItWorker("Arseny", "Arseny", "Aleevich");
            Console.WriteLine(h5.Name +" " + h5.Surname + " " + h5.Patronymic);
            h5.Add();
            Console.WriteLine(h5.Name + " " + h5.Surname + " " + h5.Patronymic);
            h5.Exist();
            Console.WriteLine(h5.Name + " " + h5.Surname + " " + h5.Patronymic);


        }
    }
}
