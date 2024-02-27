using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace lab13
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("################### 1 exercise ###################");
            Person person1 = new Person("Andei", 20);
            Person person2 = new Person("Alexiz", 19);
            Person[] people = new Person[] { person1, person2 };
            Console.WriteLine("Класс Объявлен");

            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = new FileStream("D:\\Лаба Пацей\\lab13\\lab13\\lab13\\Binary.dat", FileMode.OpenOrCreate))
            {
                binary.Serialize(fs, people);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("D:\\Лаба Пацей\\lab13\\lab13\\lab13\\Binary.dat", FileMode.OpenOrCreate))
            {
                Person[] deserilizePeople = (Person[])binary.Deserialize(fs);
                foreach (Person p in deserilizePeople)
                {
                    Console.WriteLine($"Name: {p.Name} --- Age: {p.Age}");
                }
            }

            Console.WriteLine("################### 2 exercise ###################");
            using (FileStream fs = new FileStream("D:\\Лаба Пацей\\lab13\\lab13\\lab13\\Json.json", FileMode.OpenOrCreate))
            {
                Person person3 = new Person("Volodya", 30);
                await JsonSerializer.SerializeAsync<Person>(fs, person3);
                Console.WriteLine("Data has been saved to file");
            }



            Console.WriteLine("################### 3 exercise ###################");

            Person person4 = new Person("Gans", 25);
            Console.WriteLine("Объект создан");

            XmlSerializer formatter = new XmlSerializer(typeof(Person));
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream gs = new FileStream("D:\\Лаба Пацей\\lab13\\lab13\\lab13\\Person.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(gs, person4);
                Console.WriteLine("Объект сериализован");
            }

            // десериализация
            using (FileStream gs = new FileStream("D:\\Лаба Пацей\\lab13\\lab13\\lab13\\Person.xml", FileMode.OpenOrCreate))
            {
                Person newPeople = (Person)formatter.Deserialize(gs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPeople.Name} --- Возраст: {newPeople.Age} ");

            }


            Console.WriteLine("################### 4 exercise ###################");
            //выберем все узлы корневого элемента, то есть все элементы Person:
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:\\Лаба Пацей\\lab13\\lab13\\lab13\\Person.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            //Выведем на консоль значения атрибутов Name у элементов Person:
            XmlNodeList childnode = xRoot.SelectNodes("Name");
            Console.WriteLine(childnode);


            //Допустим, нам надо получить только Возраст.Для этого надо осуществить выборку вниз по иерархии элементов:
            XmlNodeList childnod = xRoot.SelectNodes("//Person/Age");
            foreach (XmlNode n in childnod)
                Console.WriteLine(n.InnerText);


            Console.WriteLine("################### 5 exercise ###################");
            XDocument xdoc = new XDocument();
            // создаем первый элемент
            XElement Car = new XElement("Car");
            // создаем атрибут
            XAttribute CarName = new XAttribute("name", "Mersedes");
            XElement CarCompany = new XElement("company", "TasAuto");
            XElement CarPrice = new XElement("price", "40000");
            Car.Add(CarName);
            Car.Add(CarCompany);
            Car.Add(CarPrice);

            XElement Moto = new XElement("Motobike");
            XAttribute MotoName = new XAttribute("name", "Kawasaki");
            XElement MotoCompany = new XElement("company", "Tangomoto");
            XElement MotoPrice = new XElement("price", "15000");
            Moto.Add(MotoName);
            Moto.Add(MotoCompany);
            Moto.Add(MotoPrice);

            XElement Auto = new XElement("Transport");
            Auto.Add(Car);
            Auto.Add(Moto);
            // добавляем корневой элемент в документ
            xdoc.Add(Auto);
            //сохраняем документ
            xdoc.Save("D:\\Лаба Пацей\\lab13\\lab13\\lab13\\car.xml");


            XmlDocument xDoc1 = new XmlDocument();
            xDoc1.Load("D:\\Лаба Пацей\\lab13\\lab13\\lab13\\car.xml");
            XmlElement xRoot1 = xDoc1.DocumentElement;
            XmlNodeList childnodes1 = xRoot1.SelectNodes("*");
            foreach (XmlNode n2 in childnodes1)
                Console.WriteLine(n2.OuterXml);

            //Выведем на консоль значения атрибутов Name у элементов Person:
            XmlNodeList childnode1 = xRoot.SelectNodes("company");
            Console.WriteLine(childnode1);


            //Допустим, нам надо получить только Возраст.Для этого надо осуществить выборку вниз по иерархии элементов:
            XmlNodeList childnod2 = xRoot.SelectNodes("//Transport/price");
            foreach (XmlNode n in childnod2)
                Console.WriteLine(n.InnerText);

            Console.ReadLine();
        }
    }
    }
