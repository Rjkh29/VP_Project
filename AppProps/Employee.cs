using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProps
{
    public class Employee
    {
        private int Id;
        private string Name;
        private string Position;
        private string Dep;
        public int id { get => Id; set => Id = value; }
        public string name { get => Name; set => Name = value; }
        public string position { get => Position; set => Position = value; }
        public string dep { get => Dep; set => Dep = value; }
    }
}
