using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1
{
    public interface IName
    {
        void Speed();
        void Tires();
        void Title();
        void ShowInfo();
    }
    public abstract class Vehicle : IName // инспользование интерфейса в классе автомобильное средство
    {
        public abstract void Speed(); // скорость
        public abstract void Tires(); // шины
        public abstract void Title(); // название
        public void ShowInfo()
        {
            Console.WriteLine(GetType().Name);
        }
        public int Drive { get; set; }
        public int Power { get; set; }

    }
    public class Person
    {
        public void Speed(Vehicle vehicle)
        {
            vehicle.Speed();
        }
        public void CheckInfo(Vehicle vehicle)
        {
            vehicle.ShowInfo();
        }
        public void Tires(Vehicle vehicle)
        {
            vehicle.Tires();
        }
        public void Title(Vehicle vehicle)
        {
            vehicle.Title();
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
    public class Car : Vehicle, IName
    {
        public string Name { get; set; }
        public override void Speed()
        {
            Console.WriteLine(180);
        }
        public override void Tires()
        {
            Console.WriteLine(20);
        }
        public override void Title()
        {
            Console.WriteLine("BMW");
        }
        public Car(string Namesystem, int drive, int power)
        {
            this.Name = Namesystem;
            this.Drive = drive;
            this.Power = power;
        }
        public Car()
        {

        }
    }
    public class Vagon : Vehicle, IName
    {
        public string Name { get; set; }
        public override void Speed()
        {
            Console.WriteLine(100);
        }
        public override void Tires()
        {
            Console.WriteLine(18);
        }
        public override void Title()
        {
            Console.WriteLine("3 Вагон");
        }
        public Vagon(string Namesystem, int drive, int power)
        {
            this.Name = Namesystem;
            this.Drive = drive;
            this.Power = power;

        }
        public Vagon()
        {

        }
    }
    public class Express : Vehicle, IName
    {
        public string Name { get; set; }
        public override void Speed()
        {
            Console.WriteLine(120);
        }
        public override void Tires()
        {
            Console.WriteLine(16);
        }
        public override void Title()
        {
            Console.WriteLine("Могилёв-Минск");
        }
        public Express(string Namesystem, int drive, int power)
        {
            this.Name = Namesystem;
            this.Drive = drive;
            this.Power = power;
        }
        public Express()
        {

        }
    }
    public class Poezd : Vehicle, IName
    {
        public string Name { get; set; }
        public override void Speed()
        {
            Console.WriteLine(90);
        }
        public override void Tires()
        {
            Console.WriteLine(25);
        }
        public override void Title()
        {
            Console.WriteLine("12213-СССР");
        }
        public Poezd(string Namesystem, int drive, int power)
        {
            this.Name = Namesystem;
            this.Drive = drive;
            this.Power = power;
        }
        public Poezd()
        {

        }
    }
    sealed class Engine : Vehicle, IName
    {
        public string Name { get; set; }
        public override void Speed()
        {
            Console.WriteLine(20);
        }
        public override void Tires()
        {
            Console.WriteLine(10);
        }
        public override void Title()
        {
            Console.WriteLine("32443-54m");
        }
        public Engine(string Namesystem, int drive, int power)
        {
            this.Name = Namesystem;
            this.Drive = drive;
            this.Power = power;
        }
        public Engine()
        {

        }
        public override string ToString()
        {
            return "Тип объекта: " + GetType().Name + "\nНазвание танка: " + Name + "\nМощность двигателя: " + Power + "\nКол-во колёс: " + Drive + "\n" + new String('-', 50);
        }
    }
    public class Printer
    {
        public string IPrinting(Vehicle obj)
        {
            if (obj is Car c)
            {
                return "Тип объекта: " + c.GetType().Name + "\nНазвание машины: " + c.Name + "\nМощность двигателя: " + c.Power + "\nКол-во колёс: " + c.Drive + "\n" + new String('-', 50);
            }
            if (obj is Poezd t)
            {
                return "Тип объекта: " + t.GetType().Name + "\nНазвание поезда: " + t.Name + "\nМощность двигателя: " + t.Power + "\nКол-во колёс: " + t.Drive + "\n" + new String('-', 50);
            }
            if (obj is Engine b)
            {
                return "Тип объекта: " + b.GetType().Name + "\nНазвание двигателя: " + b.Name + "\nМощность двигателя: " + b.Power + "\nКол-во колёс: " + b.Drive + "\n" + new String('-', 50);
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
            Vehicle[] inventory = { new Car(), new Vagon(), new Poezd(), new Engine(), new Express() };
            Console.WriteLine(inventory.ToString());
            Car car = new Car("МАЗДА", 20, 153);
            Poezd poezd = new Poezd("wghuw24898312", 10, 214);
            Engine engine = new Engine("fkn372764383-32746shqdjbq", 30, 1245);
            foreach (var item in inventory)
            {
                person.CheckInfo(item);
                person.Speed(item);
                person.Tires(item);
                person.Title(item);
                person.ToString();
            }
            Printer printer = new Printer();
            Console.WriteLine(printer.IPrinting(car));
            Console.WriteLine(printer.IPrinting(poezd));
            Console.WriteLine(printer.IPrinting(engine));
            Console.WriteLine();

            User user = new User();
            Console.WriteLine(user.DoClone());
            Console.ReadKey(true);
        }
    }
}
