using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public delegate void User(string message);
    public class Agressor
    {

        public event User Upgrade;
        public event User Work;
        public Agressor(int point)
        {
            Point = point;
        }
        public int Point { get; set; }

        public void Help(int point)
        {
            Point += point;
            Upgrade?.Invoke($"Агессор восстановил hp: {point}");
        }
        public void Boom(int point)
        {
            if (Point >= point)
            {
                Point -= (point / 2);
                Work?.Invoke($"Добряк нанёс {point / 2} hp");
            }
            else
            {
                Point = 0;
                Work?.Invoke($"{Console.ForegroundColor= ConsoleColor.Red} У агрессора закончились hp. Текущиe hp Агрессора {Point}, Агрессор погиб. Зло повержено");
                Console.ResetColor();
            }

        }

    }

    public class Soulder
    {

        public event User Upgrade;
        public event User Work;
        public Soulder(int point)
        {
            Point = point;
        }
        public int Point { get; set; }

        public void Help(int point)
        {
            Point += (point * 2);
            Upgrade?.Invoke($"Добряк восстановил hp: {point * 2}");
        }
        public void Boom(int point)
        {
            if (Point >= point)
            {
                Point -= point;
                Work?.Invoke($"Агрессор нанёс {point} hp, ");
            }
            else
            {
                Point = 0;
                Work?.Invoke($" {Console.ForegroundColor = ConsoleColor.Green}У Добряка закончились hp. Текущиe hp Добряка {Point}, Добряк погиб");
                Console.ResetColor();
            }

        }

    }


    static class Program
    {
        static void Main(string[] args)
        {
            Agressor agressor = new Agressor(300);
            agressor.Work += UserWork;
            agressor.Boom(100);
            Console.WriteLine($" hp Воина: {agressor.Point}");
            agressor.Upgrade += UserUpgrade;
            agressor.Help(50);
            Console.WriteLine($" hp Воина: {agressor.Point}");
            agressor.Boom(150);
            Console.WriteLine($" hp Воина: {agressor.Point}");
            agressor.Help(100);
            Console.WriteLine($" hp Воина: {agressor.Point}");
            agressor.Boom(250);
            Console.WriteLine($" hp Воина: {agressor.Point}");
            agressor.Boom(300);
            Console.WriteLine($" hp Воина: {agressor.Point}");


            Console.WriteLine("###########################################################################");


            Soulder soulder = new Soulder(200);
            soulder.Work += UserWork;
            soulder.Boom(50);
            Console.WriteLine($" hp Друида: {soulder.Point}");
            soulder.Upgrade += UserUpgrade;
            soulder.Help(20);
            Console.WriteLine($" hp Друида: {soulder.Point}");
            soulder.Boom(75);
            Console.WriteLine($" hp Друида: {soulder.Point}");
            soulder.Boom(50);
            Console.WriteLine($" hp Друида: {soulder.Point}");
            soulder.Help(100);
            Console.WriteLine($" hp Друида: {soulder.Point}");
            soulder.Boom(400);
            Console.WriteLine($" hp Друида: {soulder.Point}");


            Console.WriteLine("##########################################################################");


            Console.WriteLine("Обработка методов строк");
            Func<string, string> funcStr;
            string str = "P . a!  ,  v,  ,e  . l!";
            Console.WriteLine($"Исходная строка:        {str}");
            funcStr = String.RemoveSpace;
            Console.WriteLine($"Без пробелов:           {str = funcStr(str)}");
            funcStr = String.Upper;
            Console.WriteLine($"Заглавными буквами:     {str = funcStr(str)}");
            funcStr = String.Lower;
            Console.WriteLine($"Строчными буквами:      {str = funcStr(str)}");
            funcStr = String.AddToString;
            Console.WriteLine($"С добавлением символа:  {str = funcStr(str)}");


            Console.Read();
        }
        public static void UserUpgrade(string message) => Console.WriteLine(message);
        public static void UserWork(string message) => Console.WriteLine(message);
    }
}
