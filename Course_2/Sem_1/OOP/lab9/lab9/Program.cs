using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {

            /// ===============  Инициализация экземпляров Figure =================
            Figure Triangle = new Figure("Triangle", 50000);
            Figure Circle = new Figure("Circle", 100000);
            Figure Square = new Figure("Square", 150000);
            Figure Oval = new Figure("Oval", 200000);

            /// =========  Методы для работы с коллекцией  ==========
            FigureDictionary showfigure = new FigureDictionary();
            showfigure.Add(1, Triangle);
            showfigure.Add(2, Circle);
            showfigure.Add(3, Square);
            showfigure.Add(4, Oval);
            showfigure.Delete(3);
            Console.WriteLine(new String('=', 60));
            Console.WriteLine("\n\t\t     Создание объектов:\n");
            showfigure.Print();

            /// ================  Создание обобщённого словаря  ================\
            Dictionary<int, int> genDictionary = new Dictionary<int, int>();
            for (int i = 0; i < 8; i++)
                genDictionary.Add(i, i);
            Console.WriteLine(new String('=', 60));
            Console.WriteLine("\n\t\tРабота с обощённым словарём:\n");
            Console.WriteLine("Коллекция int в словаре:");
            foreach (KeyValuePair<int, int> item in genDictionary)
                Console.WriteLine("{0}. {1}", item.Key, item.Value);

            Console.WriteLine("\nУдалить n элементов:");
            for (int i = 3; i < 6; i++)
                genDictionary.Remove(i);
            foreach (KeyValuePair<int, int> item in genDictionary)
                Console.WriteLine("{0}. {1}", item.Key, item.Value);

            Console.WriteLine("\nСловарь, преобразованный в список:");
            List<int> listOfDic = genDictionary.Values.ToList();
            foreach (int item in listOfDic)
                Console.WriteLine(item);


            Console.WriteLine("\nНайти в списке элемент 2:");
            foreach (int item in listOfDic)
                if (item == 2)
                    Console.WriteLine("В списке есть элемент 2\n");

            /// ==============  Работа с универсальной коллекцией  ================
            Stack<Figure> figure = new Stack<Figure>();
            figure.Push(Circle);
            figure.Push(Oval);
            figure.Push(Square);
            foreach (var fig in figure)
                Console.WriteLine(fig.Name);
            figure.Contains(Square);
            Figure headFigure = figure.Peek();
            Console.WriteLine(headFigure.Name);
            Figure Figure1 = figure.Pop();
            Console.WriteLine(Figure1.Name);
            Figure Figure2 = figure.Pop();
            Console.WriteLine(Figure2.Name);


       

        /// ==============  Создание наблюдаемой коллекции  ================
        ObservableCollection<Figure> obsFigures = new ObservableCollection<Figure>
            {
                new Figure("Pentagon", 400000),
                new Figure("Cylinder", 600000),
                new Figure("Cube", 200000),

            };
            Console.WriteLine(new String('=', 60));
            Console.WriteLine("\n\t\tСобытия обозреваемой коллекции:\n");
            obsFigures.Add(new Figure("Star", 700000));
            obsFigures.RemoveAt(1);
            obsFigures[2] = new Figure("Heart", 550000);

            Console.WriteLine("\nИтоговый список:");
            foreach (Figure user in obsFigures)
                Console.WriteLine(user.Name);

            Console.WriteLine();
            Console.WriteLine(new String('=', 60));
            Console.WriteLine();
            Figures figu = new Figures();
            foreach (var f in figu)
            {
                Console.WriteLine(f);
            }
            Console.ReadKey(true);
        }
    }    
}
