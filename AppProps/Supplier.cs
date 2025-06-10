using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProps
{
    public class Supplier
    {
        private int Id;
        private string Name;
        private string Cat;
        private string Loc;
        public int id { get => Id; set => Id = value; }
        public string name { get => Name; set => Name = value; }
        public string cat { get => Cat; set => Cat = value; }
        public string loc { get => Loc; set => Loc = value; }
    }
}
