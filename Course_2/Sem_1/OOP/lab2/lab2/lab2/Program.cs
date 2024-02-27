using System;

namespace lab2
{
    public partial class Train
    {
        public readonly int id;
        public static int count = 0;
        public string str;
        int time;
        public string City
        {
            get;
            set;

        }
        public int Numberoftrain
        {
            get;
            set;
        }
        public int Gotime
        {
            get
            {
                return time;
            }
            set
            {
                if (value < 25)
                {
                    Console.WriteLine("Время выбрано правильно");
                    time = value;
                }
                else
                {

                    Console.WriteLine("Время выбрано неправильно");
                    time = value % 24;

                }
            }
        }
        public int Numberofseats
        {
            get;
            set;
        }
        public int Common
        {
            get;
            set;
        }
        public int Cope
        {
            get;
            set;
        }
        public int Plackart
        {
            get;
            set;
        }
        public int Lux
        {
            get;
            set;
        }
        static Train()
        {
            count++;
            Console.WriteLine("Статический конструктор вызван");
        }
        public Train()
        {
            this.City = "Минск";
            this.Numberoftrain = 228;
            this.Gotime = 12;
            this.Numberofseats = 200;
            this.Common = 30;
            this.Cope = 70;
            this.Plackart = 75;
            this.Lux = 25;
            count++;
        }
        private Train(int x)
        {
            Console.WriteLine("Вызван приватный конструктор");
            count++;
        }
        public static string about = "Класс для информации о поезде";

        public static string GetInfo()
        {
            return about;
        }

        public Train(string City, int Numberoftrain, int Numberofseats, int Gotime, int Common, int Plackart, int Cope, int Lux)
        {
            this.City = City;
            this.Numberoftrain = Numberoftrain;
            this.Numberofseats = Numberofseats;
            this.Gotime = Gotime;
            this.Common = Common;
            this.Plackart = Plackart;
            this.Cope = Cope;
            this.Lux = Lux;
            count++;
        }
        static public int Seats()
        {
            Train Qwerty = new Train("Барановичи", 2, 150, 16, 75, 50, 15, 10);
            Console.WriteLine($"Число общих мест в поезде ");
            return Qwerty.Numberofseats;

        }


        class Program
        {
            static void Main(string[] args)
            {
                string City; int srok;
                string City2 = "Брест";
                Console.WriteLine(Train.GetInfo());
                Train Belomer = new Train("Могилёв", 1, 200, 19, 50, 50, 50, 50);
                Console.WriteLine($" \n | Иноформация о названии города {Belomer.City} | Номер поезда {Belomer.Numberoftrain} | Время отправления {Belomer.Gotime} | Число мест {Belomer.Numberofseats} \n | Число общих мест {Belomer.Common} | Число купешных мест {Belomer.Cope} | Число плацкартных мест {Belomer.Plackart} | Число люксовых мест {Belomer.Lux} |");
                Train Kerompl = new Train();
                Console.WriteLine($" \n | Иноформация о названии города {Kerompl.City} | Номер поезда {Kerompl.Numberoftrain} | Время отправления {Kerompl.Gotime} | Число мест {Kerompl.Numberofseats} \n | Число общих мест { Kerompl.Common} | Число купешных мест { Kerompl.Cope} | Число плацкартных мест {Kerompl.Plackart} | Число люксовых мест {Kerompl.Lux} | "); ;
                Train Qwerty = new Train("Барановичи", 2, 150, 16, 75, 50, 15, 10);
                Console.WriteLine($" \n | Иноформация о названии города {Qwerty.City} | Номер поезда {Qwerty.Numberoftrain} | Время отправления {Qwerty.Gotime} | Число мест {Train.Seats()} \n | Число общих мест {Qwerty.Common} | Число купешных мест {Qwerty.Cope} | Число плацкартных мест {Qwerty.Plackart} | Число люксовых мест {Qwerty.Lux} |");
                Console.WriteLine(Qwerty == Kerompl);
                Console.WriteLine(Train.Equals(Kerompl, Qwerty));
                Console.WriteLine(Train.count);
                Train Retro = new Train(City2, 2, 200, 22, 50, 50, 50, 50);
                Console.WriteLine($" \n |  Иноформация о названии города {City2} | Номер поезда {Retro.Numberoftrain} | Время отправления {Retro.Gotime} | Число мест {Retro.Numberofseats} \n | Число общих мест {Retro.Common} | Число купешных мест {Retro.Cope} | Число плацкартных мест {Retro.Plackart} | Число люксовых мест {Retro.Lux} |");
                var array = new Train[3];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = new Train();
                    Console.WriteLine();
                    Console.WriteLine("Иноформация о названии города");
                    array[i].City = Console.ReadLine();
                    Console.WriteLine("Номер поезда");
                    array[i].Numberoftrain = int.Parse(Console.ReadLine());
                    Console.WriteLine("Время отправления");
                    array[i].Gotime = int.Parse(Console.ReadLine());
                    Console.WriteLine("Число мест");
                    array[i].Numberofseats = int.Parse(Console.ReadLine());
                    Console.WriteLine("Число общих мест");
                    array[i].Common = int.Parse(Console.ReadLine());
                    Console.WriteLine("Число купешных мест");
                    array[i].Cope = int.Parse(Console.ReadLine());
                    Console.WriteLine("Число плацкартных мест");
                    array[i].Plackart = int.Parse(Console.ReadLine());
                    Console.WriteLine("Число люксовых мест");
                    array[i].Lux = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Введите пункт назначения");
                City = Console.ReadLine();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].City == City)
                    {
                        Console.WriteLine($" \n | Иноформация о названии города {array[i].City} | Номер поезда {array[i].Numberoftrain} | Время отправления {array[i].Gotime} | Число мест {array[i].Numberofseats} \n | Число общих мест {array[i].Common} | Число купешных мест {array[i].Cope} | Число плацкартных мест {array[i].Plackart} | Число люксовых мест {array[i].Lux} |");
                    }
                }
                Console.WriteLine("Введите срок");
                srok = int.Parse(Console.ReadLine());
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Gotime > srok)
                    {
                        Console.WriteLine($" \n | Иноформация о названии города {array[i].City} | Номер поезда {array[i].Numberoftrain} | Время отправления {array[i].Gotime} | Число мест {array[i].Numberofseats} \n | Число общих мест {array[i].Common} | Число купешных мест {array[i].Cope} | Число плацкартных мест {array[i].Plackart} | Число люксовых мест {array[i].Lux} |");
                    }
                }
                var obj = new { City = "Брянск", Numberoftrain = "290", Numberofseats = "500", Gotime = "13", Common = "250", Plackart = "200", Cope = "50", Lux = "0" };
            }
        }
    }
}





