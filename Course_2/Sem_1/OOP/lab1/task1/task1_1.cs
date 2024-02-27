using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_1
{
    class task1_1
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Введите имя пользователя");
            name = Console.ReadLine();
            Console.WriteLine("Введите возраст пользователя");
            int age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост пользователя");
            float height = Single.Parse(Console.ReadLine());
            Console.WriteLine("Введите первую букву фамилии");
            char firstletter = Char.Parse(Console.ReadLine());
            Console.WriteLine("Введите тип bool");
            bool agree = Boolean.Parse(Console.ReadLine());
            Console.WriteLine("Введите тип object");
            object book = Console.ReadLine();
            Console.WriteLine("Введите тип dynamic");
            dynamic mas = Console.ReadLine();
            Console.WriteLine("Тип string:" +name);
            Console.WriteLine("Тип int:"+age);
            Console.WriteLine("Тип float:"+height);
            Console.WriteLine("Тип char:"+firstletter);
            Console.WriteLine("Тип bool:"+agree);
            Console.WriteLine("Тип object:"+book);
            Console.WriteLine("Тип dynamic:"+mas+"\n");

            Console.WriteLine("Неявное преобразование:");
            float count = 7;
            long students = 31;
            ushort chairs = 56;
            byte homework = 100;

            count=age;//первое неявное преобразование
            Console.WriteLine("Из int в float:"+count);
            students = chairs;
            Console.WriteLine("Из ushort в long:"+students);
            count=chairs;
            Console.WriteLine("Из ushort в float:"+count);
            students = homework;
            Console.WriteLine("Из byte в long:"+students);
            chairs = homework;
            Console.WriteLine("Из byte в ushort:"+chairs+"\n");

            Console.WriteLine("Явное преобразование:");
            string str;
            int a;
            double c = 12.5;
            float d;
            short b;
            byte e;
            str = "123";
            a = Convert.ToInt32(str);
            Console.WriteLine("Из string в int:"+a);
            d = Convert.ToSingle(c);
            Console.WriteLine("Из double в float:"+d);
            b = Convert.ToInt16(c);
            Console.WriteLine("Из double в short:"+b);
            e = Convert.ToByte(d);
            Console.WriteLine("Из float в byte:"+e);
            c = Convert.ToDouble(e);
            Console.WriteLine("Из byte в double:"+c);

            decimal q = 456;
            object r = q;
            Console.WriteLine("Упаковка decimal в object:"+r);

            q = (decimal)r;
            Console.WriteLine("Распаковка object в decimal:"+r);


            var qwert = "tutorial";
            var qwer = "tutor";
            var qwerty = 22;
            /*qwerty = "qwerty"
             преобразование типа int в тип string(ошибка)
             */
            qwerty -= 2;
            
            Console.WriteLine("Неявно типизированная переменная:"+qwerty);

            int? k = null;
            Console.WriteLine(k);//тип nullable





        }
    }
}
