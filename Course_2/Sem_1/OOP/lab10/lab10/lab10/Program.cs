using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
           // ==========================Задание1==================================
            var teams = new List<string>
            { "June", "July", "August", "December", "January", "February",
                "September", "October", "November",
                 "March", "April", "May" };
            ///запрос выбирающий последовательность месяцев с длиной строки равной n.
            Console.WriteLine("\nЗадание 1.1\n");
            IEnumerable<string> s = teams.Where(i => i.Length > 6);
            foreach (string i in s)
            {
                Console.WriteLine(i);
            }
            ///запрос возвращающий только летние и зимние месяцы
            Console.WriteLine("\nЗадание 1.2\n");
            IEnumerable<string> v = teams.Take(6);
            foreach (var i in v)
            {
                Console.WriteLine(i);
            }
            ///запрос вывода месяцев в алфавитном порядке
            Console.WriteLine("\nЗадание 1.3\n");
            IEnumerable<string> b = teams.OrderBy(i => i);
            foreach (var i in b)
            {
                Console.WriteLine(i);
            }
            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4 - х.
            Console.WriteLine("\nЗадание 1.4\n");
            IEnumerable<string> c = teams.Where(i => (i.Contains("u") && i.Length > 4));
            foreach (var i in c)
            {
                Console.WriteLine(i);
            }

            // ==========================Задание2==================================
            Console.WriteLine("\n\t\t       Список товаров:\n");
            Trains train1 = new Trains("Поезд 1", "Польша", 12, 150);
            Trains train2 = new Trains("Поезд 2", "Германия", 9, 120);
            Trains train3 = new Trains("Поезд 3", "Норвегия", 7, 200);
            Trains train4 = new Trains("Поезд 4", "Россия", 3, 50);
            Trains train5 = new Trains("Поезд 5", "Украина", 18, 70);
            Trains train6 = new Trains("Поезд 6", "Казакстан", 22, 140);
            Trains train7 = new Trains("Поезд 7", "Польша", 2, 100);
            Trains train8 = new Trains("Поезд 8", "США", 8, 30);
            Trains train9 = new Trains("Поезд 9", "Финдляндия", 20, 300);
            Trains train10 = new Trains("Поезд 10", "Чехия", 1, 138);
            Trains train11 = new Trains("Поезд 11", "Молдова", 4, 77);
            Trains train12 = new Trains("Поезд 12", "Литва", 6, 99);

            List<Trains> listTrains = new List<Trains>() { train1, train2, train3, train4, train5, train6, train7, train8, train9, train10, train11, train12 };
            foreach (Trains m in listTrains)
            {
                Console.WriteLine(m);
            }

            ///список поездов, следующих до заданного пункта назначения;
            Console.WriteLine("\nЗадание 2.1\n");
            var namesend = from m in listTrains
                              where m.Country == "Польша"
                              select m;
            foreach (Trains m in namesend)
                Console.WriteLine(m.ToString());
            ///список товаров для заданного наименования, цена которых не превосходит заданную;
            Console.WriteLine("\nЗадание 2.2\n");
            var namesendandtime = from m in listTrains
                            where m.Sendtime > 10 && m.Country == "Польша"
                            select m;
            foreach (Trains m in namesendandtime)
                Console.WriteLine(m.ToString());
            //максимальный поезд по количеству мест
            Console.WriteLine("\nЗадание 2.3\n");
            var maxsize = listTrains.Max(i => i.size);
            var result = listTrains.FirstOrDefault(i => i.size == maxsize);
            Console.WriteLine("Самый вместительный поезд: " + result);
            //последние пять поездов по времени отправления
            Console.WriteLine("\nЗадание 2.4\n");
            var lastfive = from m in listTrains
                           orderby m.size descending
                           select m;
           int p = 0;
            foreach (var m in lastfive)
            {
                p++;
                if (p< 6)
                {
                    Console.WriteLine(m.ToString());
                }
            }
            Console.WriteLine("\nЗадание 2.5\n");
            var tsort = from m in listTrains
                        orderby m.Country ascending
                        select m;
            foreach (Trains m in tsort)
                Console.WriteLine(m.ToString());

            Console.WriteLine("\nЗадание 4-5\n");
            List<Electric> electric = new List<Electric> {
               new Electric("Поезд 1", "Польша", 12, 150),
            new Electric("Поезд 2", "Польша", 9, 150),
            new Electric("Поезд 3", "Польша", 7, 150),
            new Electric("Поезд 4", "Польша", 3, 150),
            new Electric("Поезд 5", "Польша", 18, 150),
            new Electric("Поезд 6", "Польша",22, 150),
            new Electric("Поезд 7", "Польша", 2, 150),
            new Electric("Поезд 8", "Польша", 8, 150),
            new Electric("Поезд 9", "Польша", 20, 150),
            new Electric("Поезд 10", "Польша", 1, 150),
            new Electric("Поезд 11", "Польша", 4, 150),
            new Electric("Поезд 12", "Польша", 6, 150),
        };
            var task5 =
                from m in listTrains
                join a in electric on m.sendtime equals a.sendtime_of_electric
                where a.sendtime_of_electric > 10
                orderby a.sendtime_of_electric
                select new
                {
                    countryname=m.country,
                    trainname=m.name,
                    send=m.sendtime,
                    asize=m.size
                };
            foreach (var item in task5)
            {
                Console.WriteLine($"Страна направления : {item.countryname}  Название : {item.trainname} Время отправление : {item.send} Количество мест: {item.asize}");
            }


            Console.ReadKey(true);
        }
    }
}
