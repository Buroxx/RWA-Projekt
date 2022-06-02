<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdministratorRegisteredUsers.aspx.cs" Inherits="RWA_Projekt.AdministratorRegisteredUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
     <div class="d-flex justify-content-center mt-4">
        <div>
            <asp:Repeater ID="rptUsers" runat="server">
                <HeaderTemplate>
                    <table class="table" id="myTable" style="width: max-content">
                        <thead>
                            <tr>
                                <th scope="col">ID</th>
                                <th scope="col">Name</th>
                                <th scope="col">Email</th>
                                <th scope="col">Phone</th>
                                <th scope="col">Address</th>

                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%#Eval(nameof(rwaLib.Models.User.Id))%></th>
                        <td><%#Eval(nameof(rwaLib.Models.User.UserName))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.User.Email))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.User.PhoneNumber))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.User.Address))%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
