using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProps
{
    public class Customer
    {
        private int Id;
        private string Name;
        private string Email;
        private string Address;
        public int id { get => Id; set => Id = value; }
        public string name { get => Name; set => Name = value; }
        public string email { get => Email; set => Email = value; }
        public string address { get => Address; set => Address = value; }
    }
}
