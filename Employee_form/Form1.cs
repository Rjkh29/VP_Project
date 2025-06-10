using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppProps;
using BLL;

namespace Employee_form
{
    public partial class Emp_form : Form
    {
        EmpBLL empBLL = new EmpBLL();
        public Emp_form()
        {
            InitializeComponent();
        }
        private Employee CreateEmployeeFromForm()
        {
            return new Employee
            {
                id = Convert.ToInt32(txtId.Text),
                name = txtName.Text,
                position = txtPos.Text,
                dep = txtDep.Text
            };
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Employee emp = CreateEmployeeFromForm();
            bool res = empBLL.EmpInsertBLL(emp);
            if (res)
            {
                MessageBox.Show("Employee Inserted Successfully.");
            }
            else
            {
                MessageBox.Show("Failed to Inserted Employee.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                id =
            Convert.ToInt32(txtId.Text)
            };
            bool res = empBLL.EmpDeleteBLL(emp);
            if (res)
            {
                MessageBox.Show("Employee Deleted Successfully.");
            }
            else
            {
                MessageBox.Show("Failed to Delete Employee.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee emp = CreateEmployeeFromForm();
            bool res = empBLL.EmpUpdateBLL(emp);
            if (res)
            {
                MessageBox.Show("Employee Updated Successfully.");
            }
            else
            {
                MessageBox.Show("Failed to Update Employee.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                id =
            Convert.ToInt32(txtId.Text)
            };
            Employee SpecEmp = empBLL.EmpSearchBLL(emp);
            if (SpecEmp != null)
            {
                txtName.Text = SpecEmp.name;
                txtPos.Text = SpecEmp.position;
                txtDep.Text = SpecEmp.dep;
                MessageBox.Show("Employee Found.");
            }
            else
            {
                MessageBox.Show("Employee Not Found.");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            DataTable dt = empBLL.EmpViewAllDAL(new Employee());
            DGVEmp.DataSource = dt;
        }
    }
}
