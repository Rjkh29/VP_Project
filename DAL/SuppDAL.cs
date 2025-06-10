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
    public class SuppDAL
    {
        DbCon db = new DbCon();
        public bool SuppInsertDAL(Supplier supp)
        {
            string qry = "INSERT INTO suppliers(Supp_Id, Supp_Name, Supp_Cat, Supp_Loc) VALUES('" + supp.id + "', '" + supp.name + "', '" + supp.cat + "', '" + supp.cat + "')";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public bool SuppUpdateDAL(Supplier supp)
        {
            string qry = "UPDATE suppliers SET Supp_Name = '" + supp.name + "',Supp_Cat = '" + supp.cat + "',Supp_Loc = '" + supp.loc + "' WHERE Supp_Id='" + supp.id + "'";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public bool SuppDeleteDAL(Supplier supp)
        {
            string qry = "DELETE FROM suppliers WHERE Supp_Id = '" + supp.id + "'";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }
        public Supplier SuppSerchDAL(Supplier supp)
        {
            string qry = "SELECT * FROM suppliers WHERE Supp_Id = '" + supp.id + "'";
            Supplier SpecSupp = null;
            db.con.Open();
            SqlCommand cmd = new SqlCommand(qry, db.con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                SpecSupp = new Supplier
                {
                    id = sdr.GetInt32(sdr.GetOrdinal("Supp_Id")),
                    name = sdr.GetString(sdr.GetOrdinal("Supp_Name")),
                    cat = sdr.GetString(sdr.GetOrdinal("Supp_Cat")),
                    loc = sdr.GetString(sdr.GetOrdinal("Supp_Loc"))
                };
            }
            sdr.Close();
            db.con.Close();
            return SpecSupp;
        }
        public DataTable SuppViewAllDAL(Supplier supp)
        {
            string qry = "SELECT * FROM suppliers";
            return db.GetAll(qry);
        }
    }
}
