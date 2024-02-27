using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    public interface IGeneric<T>
    {
        /*1.Создайте обобщенный интерфейсс  операциями  добавить, удалить,просмотреть.*/

        void Add(T item);
        void Delete(T item);
        void Show();
        void WriteToFile<T>();
        
    }
}
