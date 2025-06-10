using AppProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProdDAL
    {
        DbCon db = new DbCon();
        public bool ProdInsertDAL(Product prod)
        {
            string qry = "INSERT INTO products(Prod_Id, Prod_Title, Prod_Price, Prod_Stock) VALUES('" + prod.id + "', '" + prod.title + "','" + prod.price + "','" + prod.stock + "')";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public bool ProdUpdateDAL(Product prod)
        {
            string qry = "UPDATE products SET Prod_Title = '" + prod.title + "',Prod_Price = '" + prod.price + "',Prod_Stock = '" + prod.stock + "' WHERE Prod_Id='" + prod.id + "'";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public bool ProdDeleteDAL(Product prod)
        {
            string qry = "DELETE FROM products WHERE Prod_Id = '" + prod.id + "'";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public Product ProdSearchDAL(Product prod)
        {
            string qry = "SELECT * FROM products WHERE  Prod_Id = '" + prod.id + "'";
            Product SpecProd = null;
            db.con.Open();
            SqlCommand cmd = new SqlCommand(qry, db.con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                SpecProd = new Product()
                {
                    id = sdr.GetInt32(sdr.GetOrdinal("Prod_Id")),
                    title = sdr.GetString(sdr.GetOrdinal("Prod_Title")),
                    price = sdr.GetFloat(sdr.GetOrdinal("Prod_Price")),
                    stock = sdr.GetInt32(sdr.GetOrdinal("Prod_Stock"))
                };
            }
            sdr.Close();
            db.con.Close();
            return SpecProd;
        }
        public DataTable ProdViewALLDAL(Product prod)
        {
            string qry = "SELECT * FROM products";
            return db.GetAll(qry);
        }
    }
}
