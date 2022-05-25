<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdministratorApartments.aspx.cs" Inherits="RWA_Projekt.AdministratorApartments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


    <div class="container m-4">
        <div class="col-md-6">
            <asp:Repeater ID="rptApartments" runat="server">
                <HeaderTemplate>
                    <table class="table" id="myTable" style="width:max-content">
                        <thead>
                            <tr>
                                <th scope="col">Name</th>
                                <th scope="col">City</th>
                                <th scope="col">Adults</th>
                                <th scope="col">Children</th>
                                <th scope="col">Rooms</th>
                                <th scope="col">Pictures</th>
                                <th scope="col">Price</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%#Eval(nameof(rwaLib.Models.Apartment.Name))%></th>
                        <td><%#Eval(nameof(rwaLib.Models.Apartment.City))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.Apartment.MaxAdults))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.Apartment.MaxChildren))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.Apartment.TotalRooms))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.Apartment.Pictures))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.Apartment.Price))%></td>
                        <td><asp:LinkButton OnClick="ViewApartment_Click" CommandArgument="<%# Eval(nameof(rwaLib.Models.Apartment.Id)) %>" ID="LinkButton" runat="server">Open</asp:LinkButton></td>
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
