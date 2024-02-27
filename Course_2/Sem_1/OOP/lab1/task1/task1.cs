using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class task1
    {
        static void Main(string[] args)
        {
            
            string name;
            Console.WriteLine("Введите string ");
            name = Console.ReadLine();
            Console.WriteLine("Введите int");
            int age = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите double ");
            
            double weight = Double.Parse(Console.ReadLine()) ;

            Console.WriteLine("Введите char ");
            char symbol= Char.Parse(Console.ReadLine());

            Console.WriteLine("Введите bool ");
            bool include = Boolean.Parse(Console.ReadLine());

            Console.WriteLine("Введите object ");
            object tree= Console.ReadLine();



            Console.WriteLine("Введите dynamic ");
            dynamic obj = Console.ReadLine();
            


            Console.WriteLine("Тип string "+name);
            Console.WriteLine("Тип int "+age);
            Console.WriteLine("Тип double "+weight);
            Console.WriteLine("Тип bool " + include);
            Console.WriteLine("Тип char " + symbol);
            Console.WriteLine("Тип object " + tree);
            Console.WriteLine("Тип dynamic " + obj);

            Console.WriteLine();
            Console.WriteLine("Явное приобразование: ");
            byte ch1;
            short ch2;
            int ch3;
            double weihgt = 1234.7;
            age = (int)weihgt;
            Console.WriteLine("Из double в int " + age);
            long ch4=3;
            ch3 = (int)ch4;

            Console.WriteLine("Из long в int  " + age);
            ch2 = (short)ch3;

            Console.WriteLine("Из int в short" + age);
            ch1 = (byte)ch2;

            Console.WriteLine("Из short в byte " + age);
            ch1 = (byte)ch3;
            Console.WriteLine("Из int в byte " + age);

            Console.WriteLine();
            Console.WriteLine("Неявное приобразование: ");
            
            long area = age;
            byte task = 2;
            short hight;

            hight = task;
            Console.WriteLine("Из byte в short " + hight);
            age=hight;
            Console.WriteLine("Из short в int " + age);
            area = age;
            Console.WriteLine("Из int в long " + area);
            area = task;
            Console.WriteLine("Из byte в long " + area);
            age = task;
            Console.WriteLine("Из byte в int " + area);



            // упаковка 
            int i = 21;
            object j = i;
            Console.WriteLine("Упаковка int в object "+j);
            // распаковка
            i=(int)j;

            Console.WriteLine("Распаковка object в int " + j);


            //неявно типизированная переменная.
            var tip = 'a';
            var tep = "go";
            var tap = 12.3;



            int? q = null;//тип nullable
            Console.WriteLine(q);

            // tap = "aas";
            // ошибка из-за преобразования double в string(из одного типа в другой )
            tap -= 3;
            Console.WriteLine("Неявно типизированная переменная "+tap);
            Console.ReadKey(true);



        }
    }
}
