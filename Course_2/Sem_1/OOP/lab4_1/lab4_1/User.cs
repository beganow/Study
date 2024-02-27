using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_1
{
    interface ICloneable
    {
        bool DoClone();
    }
    public abstract class BaseClone
    {
        public abstract bool DoClone(bool res);
    }
    public class User : BaseClone, ICloneable
    {
        public bool DoClone()
        {
            Console.WriteLine("\nКлонирование прошло успешно!");
            return true;
        }
        public User()
        {

        }

        public override bool DoClone(bool res)
        {
            if (res)
                Console.WriteLine("Почти одинаковые методы\nКлонировние так же прошло успешно");
            else Console.WriteLine("Почти одинаковые методы\nКлонировние прошло провально!");
            return res;
        }
    }
}