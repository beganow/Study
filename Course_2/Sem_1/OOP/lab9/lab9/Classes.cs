using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lab9
{
    public class Figure 
    {
        public string Name { get; set; }
        public int Perimeter { get; set; }
        public Figure(string name, int perimeter)
        {
            Name = name;
            Perimeter = perimeter;
        }

    }

    public class FigureDictionary
    {
        public Dictionary<int, Figure> list { get; set; }
        public FigureDictionary()
        {
            list = new Dictionary<int, Figure>();
        }

        public void Print()
        {
            foreach (KeyValuePair<int, Figure> item in list)
                Console.WriteLine("{0}. {1} – {2}см", item.Key, item.Value.Name, item.Value.Perimeter);
        }

        public void Add(int key, Figure value)
        {
            list.Add(key, value);
        }
        public void Delete(int key)
        {
            list.Remove(key);
        }
    }
    public class FiguresEnumerator : IEnumerator
    {
        string[] figur;
        int position = -1;
        public FiguresEnumerator(string[] figur) => this.figur = figur;
        public object Current
        {
            get
            {
                if (position == -1 || position >= figur.Length)
                    throw new ArgumentException();
                return figur[position];
            }
        }
        public bool MoveNext()
        {
            if (position < figur.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;
    }
    public class Figures
    {
        string[] figur = { "sphere", "octagon", "rhombus", "rectangle",
                            "parallelepiped", "quadrilateral", "cone" };
        public IEnumerator GetEnumerator() => new FiguresEnumerator(figur);
    }
}
