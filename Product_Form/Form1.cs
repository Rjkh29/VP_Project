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

namespace Product_Form
{
    public partial class Product_form : Form
    {
        public Product_form()
        {
            InitializeComponent();
        }
        ProdBLL prodBLL = new ProdBLL();
        private Product CreateProductForm()
        {
            try
            {
                return new Product
                {
                    id = Convert.ToInt32(txtId.Text),
                    title = txtTitle.Text,
                    price = float.Parse(txtPrice.Text),
                    stock = Convert.ToInt32(txtStock.Text)
                };
            }
            catch
            {
                MessageBox.Show("Please enter valid values in all fields.");
                return null;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Product prod = CreateProductForm(); ;
            bool res = prodBLL.ProdInsertBLL(prod);
            if (res)
            {
                MessageBox.Show("Product Inserted Successfully!");
            }
            else
            {
                MessageBox.Show("Product Insertion Failed!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product prod = CreateProductForm();
            bool res = prodBLL.ProdDeleteBLL(prod);
            if (res)
            {
                MessageBox.Show("Product Deleted Successfully!");
            }
            else
            {
                MessageBox.Show("Product Deletion Failed!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product prod = CreateProductForm();
            bool res = prodBLL.ProdUpdateBLL(prod);
            if (res)
            {
                MessageBox.Show("Product Updated Successfully");
            }
            else
            {
                MessageBox.Show("Product Updation Failed!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Product prod = new Product
            {
                id = Convert.ToInt32(txtId.Text)
            };
            Product SpecProd = prodBLL.ProdSearchBLL(prod);
            if (SpecProd != null)
            {
                txtTitle.Text = SpecProd.title;
                txtPrice.Text = SpecProd.price.ToString();
                txtStock.Text = SpecProd.stock.ToString();
                MessageBox.Show("Product Found");
            }
            else
            {
                MessageBox.Show("Product not found");
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            DataTable dt = prodBLL.ProdViewALL(new Product());
            DGVProd.DataSource = dt;
        }
    }
}
