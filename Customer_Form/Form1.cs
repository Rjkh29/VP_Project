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

namespace Customer_Form
{
    public partial class Customer_form : Form
    {
        public Customer_form()
        {
            InitializeComponent();
        }
        CustBLL custBLL = new CustBLL();
        public Customer CreateCustForm()
        {
            return new Customer
            {
                id = Convert.ToInt32(txtId.Text),
                name = txtName.Text,
                email = txtEmail.Text,
                address = txtAdd.Text
            };
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Customer cust = CreateCustForm();
            bool res = custBLL.CustInsertBLL(cust);
            if (res)
            {
                MessageBox.Show("Record Inserted Sucessfully!");
            }
            else
            {
                MessageBox.Show("Record Inserion failed!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Customer cust = CreateCustForm();
            bool res = custBLL.CustDeleteBLL(cust);
            if (res)
            {
                MessageBox.Show("Record Deleted Successfully!");
            }
            else
            {
                MessageBox.Show("Deletion Failed!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Customer cust = CreateCustForm();
            bool res = custBLL.CustUpdateBLL(cust);
            if (res)
            {
                MessageBox.Show("Record Updated Successfully!");
            }
            else
            {
                MessageBox.Show("Updation Failed!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer
            {
                id = Convert.ToInt32(txtId.Text)
            };
            Customer SpecCust = custBLL.CustSearchBLL(cust);
            if (SpecCust != null)
            {
                txtName.Text = SpecCust.name;
                txtEmail.Text = SpecCust.email;
                txtAdd.Text = SpecCust.address;
                MessageBox.Show("Record Found!");
            }
            else
            {
                MessageBox.Show("Not Found!");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            DataTable dt = custBLL.CustViewAllBLL(new Customer());
            DGVCust.DataSource = dt;
        }
    }
}
