<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RWA_Projekt.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .center{
            margin-left:30px;
            margin-bottom:30px;
        }
    </style>
</head>
<body>
    
    <form runat="server">

        <nav class='navbar navbar-expand-lg navbar-light bg-light mb-4'>
            <div class='container-fluid'>
                <a class='navbar-brand' href='/'>RWA Apartments Admin</a>
                <button class='navbar-toggler' type='button' data-bs-toggle='collapse' data-bs-target='#navbarSupportedContent' aria-controls='navbarSupportedContent' aria-expanded='false' aria-label='Toggle navigation'>
                    <span class='navbar-toggler-icon'></span>
                </button>
            </div>
        </nav>
        <div class="center">
        <div class="mb-1">
            <label for="tbUsername" class="form-label">Username</label>
            <asp:TextBox ID="tbUsername" runat="server" class="form-control" Width="50%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorUsername" runat="server" ErrorMessage="Username is required!" ControlToValidate="tbUsername" Font-Bold="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-2">
            <label for="exampleInputPassword1" class="form-label">Password</label>
            <asp:TextBox ID="tbPassword" runat="server" class="form-control" TextMode="Password" Width="50%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validatorPassword" runat="server" ErrorMessage="Password is required!" ControlToValidate="tbPassword" Font-Bold="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary" OnClick="btnLogin_Click" />
     </div>
            </form>

    <asp:Panel ID="pnlErrorLogin" runat="server">
        <div class='alert alert-danger' role='alert'>
            <asp:Label ID="lblErrorLogin" runat="server" Text="Check the entered data again!" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
    </asp:Panel>


  

  






    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
