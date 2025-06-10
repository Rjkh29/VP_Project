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
    public class SalesDAL
    {
        DbCon db = new DbCon();

        public bool SellDAL(Sales sale)
        {
            string selectQry = "SELECT Prod_Stock, Prod_Price FROM products WHERE Prod_Id = '" + sale.pid + "'";
            SqlCommand selectCmd = new SqlCommand(selectQry, db.con);

            db.con.Open();
            SqlDataReader reader = selectCmd.ExecuteReader();

            int currentStock = 0;
            float unitPrice = 0;

            if (reader.HasRows)
            {
                reader.Read();
                currentStock = reader.GetInt32(reader.GetOrdinal("Prod_Stock"));
                unitPrice = float.Parse(reader["Prod_Price"].ToString());
            }
            else
            {
                reader.Close();
                db.con.Close();
                return false;
            }
            reader.Close();

            if (currentStock < sale.qts)
            {
                db.con.Close();
                return false;
            }

            float finalPrice = unitPrice * sale.qts;

            string insertQry = "INSERT INTO sales (Prod_Id, Qty, Final_Price, Sold_By) VALUES ('" + sale.pid + "', '" + sale.qts + "', '" + sale.fprice + "', '" + sale.soldby + "')";
            SqlCommand insertCmd = new SqlCommand(insertQry, db.con);
            insertCmd.ExecuteNonQuery();

            string updateQry = "UPDATE products SET Prod_Stock = Prod_Stock - '" + sale.qts + "' WHERE Prod_Id = '" + sale.pid + "'";
            SqlCommand updateCmd = new SqlCommand(updateQry, db.con);
            updateCmd.ExecuteNonQuery();

            db.con.Close();
            return true;
        }

        public DataTable GetAllSales()
        {
            string query = "SELECT s.Sale_Id, p.Prod_Title, s.Qty, s.Sold_By, s.Sale_Date " +
                           "FROM sales s JOIN products p ON s.Prod_Id = p.Prod_Id";
            SqlCommand cmd = new SqlCommand(query, db.con);
            DataTable dt = new DataTable();

            db.con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            db.con.Close();

            return dt;
        }

        public DataTable GetTodaysSales()
        {
            string query = "SELECT s.Sale_Id, p.Prod_Title, s.Qty, s.Sold_By, s.Sale_Date " +
                           "FROM sales s JOIN products p ON s.Prod_Id = p.Prod_Id " +
                           "WHERE CAST(s.Sale_Date AS DATE) = CAST(GETDATE() AS DATE)";
            SqlCommand cmd = new SqlCommand(query, db.con);
            DataTable dt = new DataTable();

            db.con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            db.con.Close();

            return dt;
        }
    }
}