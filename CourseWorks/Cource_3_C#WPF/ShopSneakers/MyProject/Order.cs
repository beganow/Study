using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class Order
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Full_Name { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string User_Address { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Date_Delivery { get; set; }
        public string Status_Name { get; set; }
        public string Payment_Method { get; set; }
        public decimal Price { get; set; }

        public Order(string Login, string Name, string Full_Name, string Category, string Size, string User_Address, DateTime Order_Date, DateTime Date_Delivery, string Status_Name, string Payment_Method, decimal Price) 
        {
            this.Login = Login;
            this.Name = Name;
            this.Full_Name = Full_Name;
            this.Category = Category;   
            this.Size = Size;   
            this.User_Address = User_Address;   
            this.Order_Date = Order_Date;
            this.Date_Delivery = Date_Delivery;
            this.Status_Name = Status_Name;
            this.Payment_Method = Payment_Method;
            this.Price = Price;
        }
        public Order() { }
    }
}
