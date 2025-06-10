    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales_form.aspx.cs" Inherits="Login_Page.Sales_form" %>
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Sales Form</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
        <style>
            body {
                font-family: Arial, sans-serif;
                background: linear-gradient(135deg, #28a745, #20c997);
                display: flex;
                justify-content: center;
                align-items: center;
                min-height: 100vh;
                padding: 30px;
            }

            .container {
                background: white;
                padding: 25px;
                border-radius: 12px;
                box-shadow: 0 5px 15px rgba(0,0,0,0.2);
                width: 500px;
            }

            h2 {
                text-align: center;
                color: #28a745;
                margin-bottom: 20px;
            }

            .form-group label {
                font-weight: bold;
                color: #495057;
            }

            .form-control {
                border: 2px solid #28a745;
                border-radius: 8px;
            }

            .btn-block {
                width: 100%;
                padding: 10px;
                border-radius: 6px;
                transition: 0.3s;
            }

            .btn-success {
                background: #28a745;
                color: white;
            }

            .btn-success:hover {
                background: #218838;
            }

            .sales-buttons {
                margin-top: 20px;
                display: flex;
                justify-content: space-between;
                gap: 10px;
            }

            .gridview-container {
                margin-top: 30px;
            }

            .table {
                box-shadow: 0 3px 10px rgba(0,0,0,0.1);
            }

            .message {
                text-align: center;
                margin-top: 10px;
                font-weight: bold;
                color: #dc3545;
            }
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="container">
                <h2>Pharmacy sales Management form</h2>

                <div class="form-group mb-3">
                    <label>Product Title:</label>
                    <div class="d-flex gap-2">
                        <asp:DropDownList ID="DDLProd" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                        <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-secondary" OnClick="btnShow_Click" />
                    </div>
                </div>

                <div class="form-group mb-3">
                    <label>Unit Product Price:</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label>Available Stock:</label>
                    <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label>Quantity to Sell:</label>
                    <asp:TextBox ID="txtQts" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label>Sold By:</label>
                    <asp:TextBox ID="txtSb" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label>Total Price:</label>
                    <asp:TextBox ID="txtFPrice" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>

                <asp:Button ID="btnSell" runat="server" Text="Sell" CssClass="btn btn-success btn-block" OnClick="btnSell_Click" />

                <asp:Label ID="lblMsg" runat="server" CssClass="message"></asp:Label>

                <asp:TextBox ID="txtPid" runat="server" Visible="false"></asp:TextBox>

                <div class="sales-buttons">
                    <asp:Button ID="btnViewAllSales" runat="server" Text="View All Sales" OnClick="btnViewAllSales_Click" CssClass="btn btn-primary" />
                    <asp:Button ID="btnViewTodaysSales" runat="server" Text="View Today's Sales" OnClick="btnViewTodaysSales_Click" CssClass="btn btn-info" />
                </div>

                <div class="gridview-container">
                    <asp:GridView ID="GVSales" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered table-hover" Visible="false" />
                </div>
            </div>
        </form>
    </body>
    </html>
