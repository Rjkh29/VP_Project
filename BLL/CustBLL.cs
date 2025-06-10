using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProps;
using DAL;

namespace BLL
{
    public class CustBLL
    {
        CustDAL custDAL = new CustDAL();
        public bool CustInsertBLL(Customer cust)
        {
            return custDAL.CustInsertDAL(cust);
        }
        public bool CustUpdateBLL(Customer cust)
        {
            return custDAL.CustUpdateDAL(cust);
        }
        public bool CustDeleteBLL(Customer cust)
        {
            return custDAL.CustDeleteDAL(cust);
        }
        public Customer CustSearchBLL(Customer cust)
        {
            return custDAL.CustSearchDAL(cust);
        }
        public DataTable CustViewAllBLL(Customer cust)
        {
            return custDAL.CustViewAll(cust);
        }
    }
}
