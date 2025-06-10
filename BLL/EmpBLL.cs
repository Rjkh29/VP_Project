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
    public class EmpBLL
    {
        EmpDAL empDAL = new EmpDAL();
        public bool EmpInsertBLL(Employee emp)
        {
            return empDAL.EmpInsertDAL(emp);
        }
        public bool EmpUpdateBLL(Employee emp)
        {
            return empDAL.EmpUpdateDAL(emp);
        }
        public bool EmpDeleteBLL(Employee emp)
        {
            return empDAL.EmpDeleteDAL(emp);
        }
        public Employee EmpSearchBLL(Employee emp)
        {
            return empDAL.EmpSearchDAL(emp);
        }
        public DataTable EmpViewAllDAL(Employee emp)
        {
            return empDAL.EmpViewAllDAL(emp);
        }
    }
}
