<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RWA_Projekt.Login" MasterPageFile="~/AdminMasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>Login</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .center {
            margin-left: 30px;
            margin-bottom: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
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
    <asp:Panel ID="pnlErrorLogin" runat="server">
        <div class='alert alert-danger' role='alert'>
            <asp:Label ID="lblErrorLogin" runat="server" Text="Check the entered data again!" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>
