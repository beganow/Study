using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyProject
{
    [Serializable]
    public class Items
    {
        public List<Item> list = new List<Item>();
    }
}
