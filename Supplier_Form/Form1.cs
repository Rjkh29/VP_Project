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

namespace Supplier_Form
{
    public partial class Supplier_form : Form
    {
        public Supplier_form()
        {
            InitializeComponent();
        }
        SuppBLL supBLL = new SuppBLL();
        public Supplier CreateSuppForm()
        {
            return new Supplier
            {
                id = Convert.ToInt32(txtId.Text),
                name = txtName.Text,
                cat = txtCat.Text,
                loc = txtLoc.Text
            };
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Supplier supp = CreateSuppForm();
            bool res = supBLL.SuppInsertBLL(supp);
            if (res)
            {
                MessageBox.Show("Supplier Inserted!");
            }
            else
            {
                MessageBox.Show("Supplier Insertion failed");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Supplier supp = CreateSuppForm();
            bool res = supBLL.SuppDeleteBLL(supp);
            if (res)
            {
                MessageBox.Show("Supplier Deleted!");
            }
            else
            {
                MessageBox.Show("Supplier Deletion failed");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Supplier supp = CreateSuppForm();
            bool res = supBLL.SuppUpdateBLL(supp);
            if (res)
            {
                MessageBox.Show("Supplier Updated!");
            }
            else
            {
                MessageBox.Show("Supplier Updation failed");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Supplier supp = new Supplier
            {
                id = Convert.ToInt32(txtId.Text)
            };
            Supplier SpecSupp = supBLL.SuppSearchBLL(supp);
            if (SpecSupp != null)
            {
                txtName.Text = SpecSupp.name;
                txtCat.Text = SpecSupp.cat;
                txtLoc.Text = SpecSupp.loc;
                MessageBox.Show("Record Found!");
            }
            else
            {
                MessageBox.Show("Supplier Record not found");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            DataTable dt = supBLL.SuppViewAllBLL(new Supplier());
            DGVSupp.DataSource = dt;
        }
    }
}
