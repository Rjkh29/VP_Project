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
    public class EmpDAL
    {
        DbCon db = new DbCon();

        public bool EmpInsertDAL(Employee emp)
        {
            string qry = "INSERT INTO employees (Emp_Id, Emp_Name, Emp_Pos, Emp_dep) VALUES ('" + emp.id + "', '" + emp.name + "', '" + emp.position + "', '" + emp.dep + "')";
            SqlCommand cmd = new SqlCommand(qry, db.con);

            return db.UDI(cmd);
        }

        public bool EmpUpdateDAL(Employee emp)
        {
            string qry = "UPDATE employees SET Emp_Name = '" + emp.name + "',Emp_Pos = '" + emp.position + "', Emp_dep = '" + emp.dep + "' WHERE Emp_Id ='" + emp.id + "'";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }

        public bool EmpDeleteDAL(Employee emp)
        {
            string qry = "DELETE FROM employees WHERE Emp_Id = '" + emp.id + "'";
            SqlCommand cmd = new SqlCommand(qry, db.con);
            return db.UDI(cmd);
        }

        public Employee EmpSearchDAL(Employee emp)
        {
            string qry = "SELECT Emp_Id, Emp_Name, Emp_Pos, Emp_dep FROM employees WHERE Emp_Id = '" + emp.id + "'";
            Employee SpecEmp = null;
            db.con.Open();
            SqlCommand cmd = new SqlCommand(qry, db.con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                SpecEmp = new Employee()
                {
                    id = reader.GetInt32(reader.GetOrdinal("Emp_Id")),
                    name = reader.GetString(reader.GetOrdinal("Emp_Name")),
                    position = reader.GetString(reader.GetOrdinal("Emp_Pos")),
                    dep = reader.GetString(reader.GetOrdinal("Emp_dep"))
                };
            }
            reader.Close();
            db.con.Close();
            return SpecEmp;
        }

        public DataTable EmpViewAllDAL(Employee emp)
        {
            string qry = "SELECT * FROM employees";
            return db.GetAll(qry);
        }
    }
}
