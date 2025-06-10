using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppProps;
using BLL;

namespace Login_Page
{
    public partial class Sales_form : System.Web.UI.Page
    {
        ProdBLL prodBLL = new ProdBLL();
        SalesBLL salesBLL = new SalesBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login_form.aspx");
            }
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            try
            {
                DataTable dt = prodBLL.ProdViewALL(new Product());
                DDLProd.DataSource = dt;
                DDLProd.DataTextField = "Prod_Title";
                DDLProd.DataValueField = "Prod_Id";
                DDLProd.DataBind();
                DDLProd.Items.Insert(0, new ListItem("-- Select Product --", ""));
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error loading products: " + ex.Message;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(DDLProd.SelectedValue))
                {
                    txtPid.Text = DDLProd.SelectedValue;

                    Product prod = new Product { id = int.Parse(txtPid.Text) };
                    DataTable dt = prodBLL.ProdViewALL(prod);
                    if (dt.Rows.Count > 0)
                    {
                        txtStock.Text = dt.Rows[0]["Prod_Stock"].ToString();
                        txtPrice.Text = dt.Rows[0]["Prod_Price"].ToString();
                    }
                    else
                    {
                        lblMsg.Text = "Product not found.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error fetching product details: " + ex.Message;
            }
        }
        protected void btnSell_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtQts.Text, out int qty) || qty <= 0)
                {
                    lblMsg.Text = "Please enter a valid quantity.";
                    return;
                }

                Sales sale = new Sales()
                {
                    pid = int.Parse(txtPid.Text),
                    qts = qty,
                    soldby = txtSb.Text
                };

                bool success = salesBLL.SellBLL(sale);

                if (success)
                {
                    float total = sale.qts * float.Parse(txtPrice.Text);
                    txtFPrice.Text = total.ToString("F2");
                    lblMsg.Text = "Sale recorded successfully. Stock updated.";
                    txtStock.Text = (int.Parse(txtStock.Text) - sale.qts).ToString(); // Update UI stock
                }
                else
                {
                    lblMsg.Text = "Sale failed. Possible reasons: product not found or insufficient stock.";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error during sale: " + ex.Message;
            }
        }

        protected void btnViewAllSales_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = salesBLL.GetAllSalesBLL();
                GVSales.DataSource = dt;
                GVSales.DataBind();
                GVSales.Visible = true;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error fetching all sales: " + ex.Message;
            }
        }

        protected void btnViewTodaysSales_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = salesBLL.GetTodaysSalesBLL();
                GVSales.DataSource = dt;
                GVSales.DataBind();
                GVSales.Visible = true;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error fetching today's sales: " + ex.Message;
            }
        }
    }
}