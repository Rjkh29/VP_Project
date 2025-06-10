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
    public class ProdBLL
    {
        ProdDAL prodDAL = new ProdDAL();
        public bool ProdInsertBLL(Product prod)
        {
            return prodDAL.ProdInsertDAL(prod);
        }
        public bool ProdUpdateBLL(Product prod)
        {
            return prodDAL.ProdUpdateDAL(prod);
        }
        public bool ProdDeleteBLL(Product prod)
        {
            return prodDAL.ProdDeleteDAL(prod);
        }
        public Product ProdSearchBLL(Product prod)
        {
            return prodDAL.ProdSearchDAL(prod);
        }
        public DataTable ProdViewALL(Product prod)
        {
            return prodDAL.ProdViewALLDAL(prod);
        }
    }
}
