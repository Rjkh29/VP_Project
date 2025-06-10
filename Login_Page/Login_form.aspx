<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_form.aspx.cs" Inherits="Login_Page.Login_form" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background: linear-gradient(135deg, #007bff, #6610f2);
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            padding: 30px 0;
        }

        .container {
            background: #ffffff;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
            width: 400px;
        }

        h2 {
            text-align: center;
            color: #007bff;
            margin-bottom: 20px;
        }

        .form-group label {
            font-weight: bold;
            color: #495057;
        }

        .form-control {
            border: 2px solid #007bff;
            border-radius: 8px;
            width: 100%;
            padding: 6px;
        }

        .btn-login {
            width: 100%;
            padding: 10px;
            background: #007bff;
            color: white;
            border: none;
            border-radius: 6px;
            cursor: pointer;
            transition: 0.3s;
        }

        .btn-login:hover {
            background: #0056b3;
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
            <h2>Login to Pharmacy Management System</h2>

            <div class="form-group">
                <label>Username:</label><br />
                <asp:TextBox ID="txtUsername" runat="server" Placeholder="Enter your username" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label>Password:</label><br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Enter your password" CssClass="form-control"></asp:TextBox>
            </div>

            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn-login" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
        </div>
    </form>
</body>
</html>
