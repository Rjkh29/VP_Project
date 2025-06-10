using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProps
{
    public class Sales
    {
        private int QTS;
        private string SoldBy;
        private string Title;
        private float FPrice;
        private int Stock;
        private int SaleId;
        private int PID;

        public string soldby { get => SoldBy; set => SoldBy = value; }
        public int qts { get => QTS; set => QTS = value; }
        public string title { get => Title; set => Title = value; }
        public float fprice { get => FPrice; set => FPrice = value; }
        public int stock { get => Stock; set => Stock = value; }
        public int saleid { get => SaleId; set => SaleId = value; }
        public int pid { get => PID; set => PID = value; }
    }
}
