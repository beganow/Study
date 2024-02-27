using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace lab5
{
    abstract public partial class TransportAgency
    {
        public List<Vehicle> TAgency;
        public TransportAgency()
        {
            TAgency = new List<Vehicle>();
        }
        public void Delete(int index)
        {
            TAgency.RemoveAt(index);
        }
        public void Add(Vehicle item)
        {
            TAgency.Add(item);
        }
        public void Display()
        {
            foreach (Vehicle item in TAgency)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
    public class TransportController : TransportAgency
    {
        public void SearchSpeed(TS ts)
        {
            int speed = 0; 
           
            Console.WriteLine("\nПоиск транспортного средства {0}.{1}.{2}", ts.Skoda, ts.Mersedes, ts.Audi);
            Console.WriteLine("Скорости:");
            for (int i = 0; i < TAgency.Count; i++)
            {   if (TAgency[i].NameTS.Length < 2)
                    throw new NameException("Ошибка назвнии авто", TAgency[i].NameTS);
                Console.WriteLine(TAgency[i].NameTS +" " +TAgency[i].Speedscore);
            }
            for (int i = 0; i < TAgency.Count; i++)
                {
                    if (TAgency[i].Speedscore < 165)
                {
                    speed = TAgency[i].Speedscore;
                }
            }  
            Console.WriteLine("Ваша скорость попала в диапазон : 165" );


        }
       
        public void GetPrice()
        {
            int price = 0;
            for (int i = 0; i < TAgency.Count; i++)
            {
                price += TAgency[i].Price;
            }
            if (price < 600000 || price > 1000000)
                throw new SearchPowerException("Ошибка! Неверно введена стоимость  для поиска:", price);
            Console.WriteLine("\n Стоимость всех авто: " + price);
        }
        public void SearchFuel()
        {
            int min;
            for (int i=0;i<TAgency.Count; i++)
            {
                for (int j = i+1; j < TAgency.Count; j++)
                {
                    if (TAgency[i].Fuel > TAgency[j].Fuel)
                    {
                        min = TAgency[i].Fuel;
                        TAgency[i].Fuel = TAgency[j].Fuel;
                        TAgency[j].Fuel = min;
                    }
                }
            }
            Console.WriteLine("Вывод сортировки:");
           for (int i = 0; i < TAgency.Count; i++)
           {
               Console.WriteLine(TAgency[i].NameTS + " " +TAgency[i].Fuel);
            }
        }
    }


}