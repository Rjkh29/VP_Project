using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbCon
    {
        public SqlConnection con;
        public DbCon()
        {
            con = new SqlConnection("Data Source=DESKTOP-7KEI81B;Initial Catalog=VP_DB;Integrated Security=True;Encrypt=False;");
        }
        public bool UDI(SqlCommand cmd)
        {
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result > 0;
        }
        public DataTable GetAll(string qry)
        {
            SqlCommand cmd = new SqlCommand(qry,con);
            DataTable dt = new DataTable();
            con.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();
            return dt;
        }
    }
}
