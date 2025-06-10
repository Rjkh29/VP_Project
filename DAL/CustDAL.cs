using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppProps;

namespace DAL
{
    public class CustDAL
    {
        DbCon db = new DbCon();
        public bool CustInsertDAL(Customer cust)
        {
            string qry = "INSERT INTO customers(Customer_Id, Customer_Name, Customer_Email, Customer_Add) VALUES('" + cust.id + "', '" + cust.name + "', '" + cust.email + "', '" + cust.address + "') ";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public bool CustUpdateDAL(Customer cust)
        {
            string qry = "UPDATE customers SET Customer_Name = '" + cust.name + "',Customer_Email = '" + cust.email + "',Customer  _Add = '" + cust.address + "' WHERE Customer_Id = '" + cust.id + "'";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public bool CustDeleteDAL(Customer cust)
        {
            string qry = "DELETE FROM customers WHERE Customer_Id = '" + cust.id + "'";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public Customer CustSearchDAL(Customer cust)
        {
            string qry = "SELECT * FROM customers WHERE Customer_Id='" + cust.id + "'";
            Customer SpecCust = null;
            db.con.Open();
            SqlCommand cmd = new SqlCommand(qry, db.con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                SpecCust = new Customer()
                {
                    id = sdr.GetInt32(sdr.GetOrdinal("Customer_Id")),
                    name = sdr.GetString(sdr.GetOrdinal("Customer_Name")),
                    email = sdr.GetString(sdr.GetOrdinal("Customer_Email")),
                    address = sdr.GetString(sdr.GetOrdinal("Customer_Add"))
                };
            }
            sdr.Close();
            db.con.Close();
            return SpecCust;
        }
        public DataTable CustViewAll(Customer cust)
        {
            string qry = "SELECT * FROM customers";
            return db.GetAll(qry);
        }
    }
}
