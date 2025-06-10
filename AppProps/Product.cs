using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProps
{
    public class Product
    {
        private int Id;
        private string Title;
        private float Price;
        private int Stock;
        public int id { get => Id; set => Id = value; }
        public string title { get => Title; set => Title = value; }
        public float price { get => Price; set => Price = value; }
        public int stock { get => Stock; set => Stock = value; }
    }
}
