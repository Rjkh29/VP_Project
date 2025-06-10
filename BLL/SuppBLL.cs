using AppProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SuppBLL
    {
        SuppDAL suppDAL = new SuppDAL();
        public bool SuppInsertBLL(Supplier supp)
        {
            return suppDAL.SuppInsertDAL(supp);
        }
        public bool SuppUpdateBLL(Supplier supp)
        {
            return suppDAL.SuppUpdateDAL(supp);
        }
        public bool SuppDeleteBLL(Supplier supp)
        {
            return suppDAL.SuppDeleteDAL(supp);
        }
        public Supplier SuppSearchBLL(Supplier supp)
        {
            return suppDAL.SuppSerchDAL(supp);
        }
        public DataTable SuppViewAllBLL(Supplier supp)
        {
            return suppDAL.SuppViewAllDAL(supp);
        }
    }
}
