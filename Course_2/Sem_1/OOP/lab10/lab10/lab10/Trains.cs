using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Trains
    {
        //Поля
        public readonly int id;
        public string name;
        public string country;
        public int sendtime;
        public int size;
        public static short numberOfTrain = 0;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrEmpty(name))
                    name = value;
                else Console.WriteLine("Ошибка! Неверное название поезда.");
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (!String.IsNullOrEmpty(country))
                    country = value;
                else Console.WriteLine("Ошибка! Неверно задана страна пункта назначения .");
            }
        }
        public int Sendtime
        {
            get
            {
                return sendtime;
            }
            set
            {
                if (sendtime > 24)
                    sendtime = value;
                else Console.WriteLine("Ошибка! Неверное время отправления .");
            }
        }
        public Trains(string tName, string tCountry, int tSendtime, int tsize)
        {
            name = tName;
            country = tCountry;
            sendtime = tSendtime;
            size = tsize;
            id = GetHashCode();
            numberOfTrain++;
        }
        public override string ToString()
        {
            return $"Название: {name}; Страна: {country}; Время отправления {sendtime}; Размерность мест {size} ";
        }


    }

      public class Electric
    {
        public readonly int id_of_electric;
        public string  name_of_electric { get; set; }

        public string country_of_electric { get; set; }
        public int sendtime_of_electric { get; set;  }
        public int esize { get; set; }
        public static short numberOfTrain = 0;
        public Electric() { }
        public Electric( string name_of_electric, string country_of_electric, int sendtime_of_electric, int esize)
        {
            this.name_of_electric = name_of_electric;
            this.country_of_electric = country_of_electric;
            this.sendtime_of_electric = sendtime_of_electric;
            this.esize = esize;
        }
    }
}
