﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Login_Page
{
    public partial class Login_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username == "admin" && password == "admin")
            {
                Session["User"] = username;
                Response.Redirect("Sales_form.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid credentials, please try again!";
            }
        }
    }
}