using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    [Serializable]
   public class Item
   {
        public string Name { get; set; }
        public string FullName
        {get; set;}
        public string Image { get; set; }
        public string Category { get; set; }
        public double Rate { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public static Item selectedItem { get;  set; }

        public Item(string Name, string FullName, string Image, string Category, double Rate, int Size, int Count, double Price)
        {
            this.Name = Name;
            this.FullName = FullName;
            this.Image = Image;
            this.Category = Category;
            this.Rate = Rate;
            this.Size = Size;
            this.Count = Count;
            this.Price = Price;
        }
        public Item() { }
    }
}
