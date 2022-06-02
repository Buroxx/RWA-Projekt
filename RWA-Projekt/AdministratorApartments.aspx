<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdministratorApartments.aspx.cs" Inherits="RWA_Projekt.AdministratorApartments"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


    <div class="mt-4 d-flex justify-content-center">
        <div>
            <asp:Repeater ID="rptApartments" runat="server">
                <HeaderTemplate>
                    <table class="table" id="myTable" style="width: max-content">
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
                        <td><%#Eval(nameof(rwaLib.Models.Apartment.NumberOfPictures))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.Apartment.Price))%>€</td>
                        <td>
                            <asp:Button Text=" EDIT " runat="server" CssClass="btn btn-primary" CommandArgument="<%# Eval(nameof(rwaLib.Models.Apartment.Id)) %>" OnClick="ViewApartment_Click" ID="LinkButton" /></td>
                        <td>
                            <asp:Button Text="DELETE" runat="server" CssClass="btn btn-danger" CommandArgument="<%# Eval(nameof(rwaLib.Models.Apartment.Id)) %>" OnClick="btnDeleteModal_Click" ID="btnDeleteModal" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>



    <asp:Panel runat="server" ID="pnlModal" Visible="false">
        <div class="modal" tabindex="-1" role="dialog" style="display: block">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Delete this apartment?</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="remove()">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure that you want to delete this apartment?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDeleteApartment" Text="DELETE" runat="server" CssClass="btn btn-danger" OnClick="btnDeleteApartment_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="remove()">Close</button>
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>

    <script>
        function remove() {
            $('.modal').hide();
        }
    </script>


</asp:Content>
