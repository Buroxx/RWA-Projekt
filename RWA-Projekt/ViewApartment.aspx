<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewApartment.aspx.cs" Inherits="RWA_Projekt.ViewApartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="CSS/ImageGalery.css" rel="stylesheet" />
    <title id="title"></title>
    <style>
        .container {
            margin-bottom: 50px;
        }

        .buttons {
            margin-top: 50px;
        }

        .registered {
            margin-top: 50px;
            width: 80%;
        }

        .gv {
            margin-top: 50px;
            width: 50%;
        }
        .unregistered{
            display:flex;
            justify-content:center;
            align-items:center;
            margin-top:50px;
            flex-direction:column;
            width:100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


    <div class="container">
        <asp:Repeater ID="rptImgs" runat="server">
            <ItemTemplate>
                <div class="mySlides">
                    <img src="<%# Eval(nameof(rwaLib.Models.ApartmentPicture.Path)) %>" style="width: 100%">
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
        <a class="next" onclick="plusSlides(1)">&#10095;</a>
    </div>
    <asp:Label runat="server" ID="lblName" Text="Apartment name: " />
    <asp:TextBox ID="tbName" runat="server"></asp:TextBox>

    <asp:Label runat="server" ID="lblPrice" Text="Price: " />
    <asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>

    <asp:Label runat="server" ID="lblCity" Text="City: " />
    <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>

    <asp:Label runat="server" ID="lblAdults" Text="Adult rooms: " />
    <asp:TextBox ID="tbAdults" runat="server"></asp:TextBox>

    <asp:Label runat="server" ID="lblChildren" Text="Children rooms: " />
    <asp:TextBox ID="tbChildren" runat="server"></asp:TextBox>

    <asp:Label runat="server" ID="lblRooms" Text="Total rooms: " />
    <asp:TextBox ID="tbRooms" runat="server"></asp:TextBox>
    <asp:Label runat="server" ID="lbStatus" Text="Status: " />
    <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

    <div class="buttons">
        <asp:Panel ID="pnlOption" runat="server">
            <asp:Button ID="btnRegistered" runat="server" Text="Registered user" OnClick="btnRegistered_Click" />
            <asp:Button ID="btnUnregistered" runat="server" Text="Unregistered user" OnClick="btnUnregistered_Click" />
        </asp:Panel>
    </div>


    <%-- BUTTON REGISTERED --%>
    <div class="registered">
        <asp:Panel ID="pnlRegistered" runat="server">
            <asp:Repeater ID="rptUsers" runat="server">
                <HeaderTemplate>
                    <table class="table" id="myTable" style="width: max-content">
                        <thead>
                            <tr>
                                <th scope="col">First name</th>
                                <th scope="col">Last name</th>
                                <th scope="col">Email</th>
                                <th scope="col">Phone number</th>
                                <th scope="col">Address</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th scope="row"><%#Eval(nameof(rwaLib.Models.User.FirstName))%></th>
                        <td><%#Eval(nameof(rwaLib.Models.User.LastName))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.User.Email))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.User.PhoneNumber))%></td>
                        <td><%#Eval(nameof(rwaLib.Models.User.Address))%></td>
                        <td>
                            <asp:LinkButton OnClick="PickPerson_Click" CommandArgument="<%# Eval(nameof(rwaLib.Models.User.Id)) %>" ID="PickPerson" runat="server">Pick</asp:LinkButton></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>

    </div>
    <div class="gv">
        <asp:GridView ID="gvPickedUser" runat="server" AutoGenerateColumns="false" CssClass="table">
            <Columns>
                <asp:BoundField HeaderText="First name" DataField="FirstName" />
                <asp:BoundField HeaderText="Last name" DataField="LastName" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Phone number" DataField="PhoneNumber" />
                <asp:BoundField HeaderText="Address" DataField="Address" />
            </Columns>
        </asp:GridView>
    </div>

    <%-- BUTTON UNREGISTERED --%>
    <asp:Panel ID="pnlUnregistered" runat="server">
    <div class="unregistered">
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">First name</label>
            <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Last name</label>
            <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Email</label>
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>

        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Phone number</label>
            <asp:TextBox ID="tbPhoneNumber" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Address</label>
            <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox>
        </div>
        <button type="submit" class="btn btn-primary">Submit</button>
    </div>
    </asp:Panel>


    <script src="Scripts/ImageGalery.js"></script>
</asp:Content>
