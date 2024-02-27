using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab5
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
        public string NameTS { get;  set; }
        public string Name { get; internal set; }
        public object TS { get; internal set; }
        public int Price { get; set; }
        public int Fuel { get; set; }
        public int Speedscore { get; set; }
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
            public Car(string Namesystem, int drive, int power, int price, int fuel, int speed)
            {
                this.NameTS = Namesystem;
                this.Name = Namesystem;
                this.Drive = drive;
                this.Power = power;
                this.Price = price;
                 this.Fuel = fuel;
                this.Speedscore = speed;
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
    public struct TS
    {
        public string Skoda;
        public string Mersedes;
        public string Audi;


        public TS(string skoda, string mersedes, string audi)
        {
            this.Skoda = skoda;
            this.Mersedes = mersedes;
            this.Audi = audi;
        }
        enum Operation
        {
            Add = 1,
            Delete,
            Display,
            SearchFuel,
            SearchSpeed,
            GetPrice
        }




    }
    class Program
        {
            static void Main(string[] args)
            {
            /*int x = 2;
            int y = 2;
            int q = x + y;
            Console.WriteLine("This is C# Assert Example.");
            Debug.Assert(q != 4, "Addition should not be 4.");
            Console.WriteLine("\n This is after assert method.");*/
            Person person = new Person { Name = "Pavel" };
                Console.WriteLine(person.ToString());
                Vehicle[] inventory = { new Car(), new Vagon(), new Poezd(), new Engine(), new Express() };
                Console.WriteLine(inventory.ToString());
                Car car = new Car("МАЗДА", 153 , 8700, 120000, 20, 150);
                Poezd poezd = new Poezd("wghuw24898312", 40, 214 );
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

                User1 user = new User1();
                Console.WriteLine(user.DoClone());
            FileLogger fileLogger = new FileLogger();
            ConsoleLogger consoleLogger = new ConsoleLogger();
            try
            {
                TransportController transportagent = new TransportController();
                Car Skoda = new Car("S", 500, 8700, 120000, 7, 120);
                Car Mersedes = new Car("Mersedes", 550, 8800, 200000, 20, 0);
                Car Audi = new Car("Audi", 600, 7700, 180000, 30, 10);
                transportagent.TAgency.Add(Skoda);
                transportagent.TAgency.Add(Mersedes);
                transportagent.TAgency.Add(Audi);
                Console.WriteLine("\n");
                Console.WriteLine($"Количество автомобилей {transportagent.TAgency.Count} \n\n Название {Skoda.Name} \n Количество колёс {Skoda.Drive} \n  Мощность двигателя {Skoda.Power} \n  Цена авто {Skoda.Price} \n Расход топлива {Skoda.Fuel} \n Максимальная скорость {Skoda.Speedscore}");
                Console.WriteLine($" \n\n Название {Mersedes.Name} \n Количество колёс {Mersedes.Drive} \n  Мощность двигателя {Mersedes.Power} \n  Цена авто {Mersedes.Price} \n Расход топлива {Mersedes.Fuel} \n Максимальная скорость {Mersedes.Speedscore}");
                Console.WriteLine($" \n\n Название {Audi.Name} \n Количество колёс {Audi.Drive} \n  Мощность двигателя {Audi.Power} \n  Цена авто {Audi.Price} \n Расход топлива {Audi.Fuel} \n Максимальная скорость {Audi.Speedscore}\n");
                transportagent.SearchSpeed(new TS());
                //transportagent.GetPrice();
                Console.WriteLine();
                transportagent.SearchFuel();
                Console.WriteLine();
               
               
            }
            catch(MyException ex)
            {
                fileLogger.WriteLog(ex);
                consoleLogger.WriteLog(ex);
            }
            finally { }
             Console.ReadKey(true);
        }
        }
    }

