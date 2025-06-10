using AppProps;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SalesBLL
    {
        SalesDAL salesDAL = new SalesDAL();

        public bool SellBLL(Sales sale)
        {
            return salesDAL.SellDAL(sale);
        }
        public DataTable GetAllSalesBLL()
        {
            return salesDAL.GetAllSales();
        }

        public DataTable GetTodaysSalesBLL()
        {
            return salesDAL.GetTodaysSales();
        }
    }
}
