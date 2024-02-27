using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_2
{
    class task1_2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Как дела?");

            //сравнение строк
            string s1, s2;
            s1 = "Книга";
            s2 = "книга";
            if (s1 == s2)
            {
                Console.WriteLine($"Строка {s1} равна строке {s2}");
            }
            else
            {
                Console.WriteLine($"Строка {s1} не равна строке {s2}");


                //сцепление строк
                string str1 = "Я хочу ";
                string str2 = " учить качественно";
                string str3 = " язык программирования";
                str1 = str1 + str2 + str3;//сцепление
                Console.WriteLine(str1);


                string s5 = "apple";
                string s6 = "a day";
                string s7 = "keeps";
                string s8 = "a doctor";
                string s9 = "away";
                string[] values = new string[] { s5, s6, s7, s8, s9 };
                string s10 = string.Join(" ", values);//сцепление через Join
                Console.WriteLine(s10);

                //разделение строки
                string text = "Сегодня хорошая погода";
                string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//разделение строки на подстроки убирая пустые подстроки
                foreach (string word in words)
                {
                    Console.WriteLine($"<{word}>");
                }


                //обрезка строки

                int startposition = s10.IndexOf(" ") + 1;
                string word1 = s10.Substring(startposition, s10.IndexOf(" ", startposition) - startposition);
                Console.WriteLine("substring word:" + word1);

                //Удаление первых двух 
                str1.Remove(0, 2);
                Console.WriteLine("Remove:"+str1);

                //Втавка
                str3 = "How are you?";
                str1 = str1.Insert(7, str3);
                Console.WriteLine(str1);

                //замена
                str1 = str1.Replace("How", "HOW");
                Console.WriteLine(str1);

                string str5 = String.Empty;//пустая строка
                string str6 = null;// null строка

                Console.WriteLine(str5);
                Console.WriteLine(str6);


                bool b;
                b = String.IsNullOrEmpty(str5);
                Console.WriteLine(b);
                b = String.IsNullOrEmpty(str6);
                Console.WriteLine(b);

                StringBuilder s = new StringBuilder("How ", 22);
                s.Append("are");
                Console.WriteLine(s);
                s.Replace("are", " ");
                s.Insert(0, "you ");
                Console.WriteLine(s);
                s.Remove(2, 3);
                Console.WriteLine(s);
                Console.ReadKey(true);
            }
        }
    }
}
