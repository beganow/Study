using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Model
{
    class DataLector
    {
        public static List<Lector> GetAllLectors()
        {
            var result = new List<Lector>()
            {
                new Lector(){ IdLector =0,Name="Ludmila" ,Surname="Olegovna", Subject="OOP", Date= new DateTime(2023, 6, 2), interval = 120},
               new Lector(){ IdLector =1,Name="Andrey" ,Surname="Vladimirovich", Subject="Design", Date= new DateTime(2023, 6, 7), interval = 120},
               new Lector(){ IdLector =2,Name="Nikita" ,Surname="Vicktorovich", Subject="CMS", Date= new DateTime(2023, 6, 13), interval = 120},
            };
            return result;
        }
    }
}
