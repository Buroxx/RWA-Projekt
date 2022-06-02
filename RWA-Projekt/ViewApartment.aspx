<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ViewApartment.aspx.cs" Inherits="RWA_Projekt.ViewApartment"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="CSS/ImageGalery.css" rel="stylesheet" />
    <title id="title"></title>
    <style>
        .left {
            margin-left: 10px;
        }

        .registered {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .paginate_button {
            position: static;
            font-weight: normal;
            font-size: inherit;
        }

        .tablica {
            border: none;
        }
    </style>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
 

    <%-- INFO PANEL --%>
    <div class="container d-flex h-75" style="width: 800px">
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


    <asp:Panel runat="server" ID="pnlInfoForm" Visible="true">
        <div class=" d-flex justify-content-center gap-4 ">

            <div class="py-2">
                <asp:Label runat="server" ID="lblName" Text="Apartment name: " />
                <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Apartment name is empty!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbName" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <div class="py-2">
                <asp:Label runat="server" ID="lblCity" Text="Price(€):" />
                <asp:TextBox ID="tbPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbPrice" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="d-flex justify-content-center mt-2 gap-4 align-align-items-center">

            <div>
                <asp:Label runat="server" ID="lblAdults" Text="Adult rooms:" />
                <asp:TextBox ID="tbAdults" runat="server" Width="50px" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAdults" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbAdults" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div>
                <asp:Label runat="server" ID="lblChildren" Text="Children rooms:" />
                <asp:TextBox ID="tbChildren" runat="server" Width="50px" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvChildren" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbChildren" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div>
                <asp:Label runat="server" ID="lblRooms" Text="Total rooms:" />
                <asp:TextBox ID="tbRooms" runat="server" Width="50px" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRooms" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbRooms" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label runat="server" ID="Label7" Text="Beach distance: " />
                <asp:TextBox ID="tbBeachDistance" runat="server" Width="60px" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvBeach" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbBeachDistance" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

    </asp:Panel>

    <%-- BAD FORM --%>
    <asp:Panel ID="pnlBadForm" runat="server" Visible="false">
        <div class='alert alert-danger' role='alert'>
            <asp:Label ID="lblErrorLogin" runat="server" Text="Check the entered data again!" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
    </asp:Panel>


    <%-- BUTTONS SAVE CANCEL --%>
    <asp:Panel runat="server" ID="pnlSaveCancel">
        <div class="d-flex justify-content-center mt-2 gap-2">
            <asp:Button ID="btnSave" runat="server" Text=" Save " CssClass="btn btn-success" Font-Bold="True" OnClick="btnSave_Click" />
            <asp:Button ID="btnResetForm" runat="server" Text="Reset " CssClass="btn btn-dark" Font-Bold="True" OnClick="btnResetForm_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-warning" Font-Bold="True" OnClick="btnCancel_Click" />
        </div>
    </asp:Panel>



    <%-- STATUS --%>
    <div class="d-flex justify-content-center mt-2 gap-4 align-align-items-center">
        <asp:Label runat="server" ID="lbStatus" Text="Status: " />
        <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
    </div>





    <%-- BUTTONS --%>
    <div class="d-flex justify-content-center mt-2">
        <asp:Panel ID="pnlOption" runat="server" Visible="false">
            <asp:Button ID="btnRegistered" runat="server" Text="Registered user" OnClick="btnRegistered_Click" CssClass="btn btn-secondary" Font-Bold="True" />
            <asp:Button ID="btnUnregistered" runat="server" Text="Unregistered user" OnClick="btnUnregistered_Click" CssClass="btn btn-secondary" Font-Bold="True" />
        </asp:Panel>
    </div>



    <%-- BUTTON REGISTERED --%>
    <asp:Panel ID="pnlRegistered" runat="server" Visible="true">
        <div class="container mt-2 d-flex justify-content-center">
            <div>
                <asp:Repeater ID="rptUsers" runat="server">
                    <HeaderTemplate>
                        <table class="table table-striped" id="myTable" style="width: 1000px">
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
                                <asp:LinkButton OnClick="PickPerson_Click" CommandArgument="<%# Eval(nameof(rwaLib.Models.User.Id)) %>" ID="PickPerson" runat="server">Pick</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </asp:Panel>



    <%-- PICKED USER --%>
    <asp:GridView ID="gvPickedUser" runat="server" AutoGenerateColumns="false" CssClass="d-flex justify-content-center mt-2 table tablica">
        <Columns>
            <asp:BoundField HeaderText="First name" DataField="FirstName" />
            <asp:BoundField HeaderText="Last name" DataField="LastName" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Phone number" DataField="PhoneNumber" />
            <asp:BoundField HeaderText="Address" DataField="Address" />
        </Columns>
    </asp:GridView>
    <asp:Panel runat="server" ID="pnlRegisteredDetails">
        <div class="d-flex-column justify-content-center mt-2">
            <asp:Label runat="server" ID="Label8" Text="Details:" />
            <asp:TextBox ID="tbRegisteredDetails" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlBtnAddRegisteredUser" runat="server" Visible="false">
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnAddRegisteredUser" runat="server" Text="Add user" CssClass="btn btn-success" Font-Bold="True" OnClick="btnAddRegisteredUser_Click" />
        </div>
    </asp:Panel>


   


    <%-- BUTTON UNREGISTERED --%>
    <asp:Panel ID="pnlUnregistered" runat="server" Visible="false">
        <div class="d-flex justify-content-center gap-4 mt-1">
            <div>
                <asp:Label runat="server" ID="Label1" Text="First name: " />
                <asp:TextBox ID="tbFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="valGroupUnregistered" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbFirstName" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationGroup="valGroupUnregistered" Display="Dynamic" ValidationExpression="[a-zA-Z-Š-š-Đ-đ-Ž-ž-Č-č-Ć-ć]+" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Characters only!" Font-Bold="true" ForeColor="red" ControlToValidate="tbFirstName"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="Label2" Text="Last name: " />
                <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="valGroupUnregistered" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbLastName" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ValidationGroup="valGroupUnregistered" Display="Dynamic" ValidationExpression="[a-zA-Z-Š-š-Đ-đ-Ž-ž-Č-č-Ć-ć]+" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Characters only!" Font-Bold="true" ForeColor="red" ControlToValidate="tbLastName"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="d-flex justify-content-center gap-4">

            <div class="mb-3">
                <asp:Label runat="server" ID="Label3" Text="Email:" />
                <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="valGroupUnregistered" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbEmail" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="Label4" Text="Phone number:" />
                <asp:TextBox ID="tbPhoneNumber" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="valGroupUnregistered" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbPhoneNumber" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="d-flex justify-content-center gap-4 mb-3">
            <div>
                <asp:Label runat="server" ID="Label5" Text="Address:" />
                <asp:TextBox ID="tbAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="valGroupUnregistered" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbAddress" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label runat="server" ID="Label6" Text="Details:" />
                <asp:TextBox ID="tbDetails" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="d-flex justify-content-center">
            <asp:Button ValidationGroup="valGroupUnregistered" ID="btnAddUser" runat="server" Text="Pick User" CssClass="btn btn-success" Font-Bold="True" OnClick="btnAddUser_Click" />
        </div>


    </asp:Panel>


    <asp:GridView ID="gvAddedUser" runat="server" AutoGenerateColumns="false" CssClass="d-flex justify-content-center mt-2 table tablica">
        <Columns>
            <asp:BoundField HeaderText="First name" DataField="FirstName" />
            <asp:BoundField HeaderText="Last name" DataField="LastName" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Phone number" DataField="PhoneNumber" />
            <asp:BoundField HeaderText="Address" DataField="Address" />
        </Columns>
    </asp:GridView>
    <asp:Panel runat="server" ID="pnlAddUnregisteredBTN" Visible="false">
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnAddUnregisteredUser" runat="server" Text="Add User" CssClass="btn btn-success" Font-Bold="True" OnClick="btnAddUnregisteredUser_Click" />
        </div>
    </asp:Panel>



    <%-- REPRESENT PICS --%>

    <div class="d-flex justify-content-center mt-2 gap-4">
        <div>
            <asp:Button ID="btnRepresentative" runat="server" Text="Change representative" CssClass="btn btn-secondary" Font-Bold="True" OnClick="btnRepresentative_Click" />
        </div>
    </div>


    <div class="d-flex justify-content-center mt-2 gap-4">
        <asp:Button ID="btnAddPictures" runat="server" Text="Add Pictures" CssClass="btn btn-secondary" Font-Bold="True" OnClick="btnAddPictures_Click" />
    </div>

    <div class="d-flex justify-content-center mt-2 gap-4">
        <asp:Button ID="btnEditPictures" runat="server" Text="Edit Pictures" CssClass="btn btn-secondary" Font-Bold="True" OnClick="btnEditPictures_Click" />
    </div>
        <div class="d-flex justify-content-center mt-2 gap-4">
        <asp:Button ID="btnTag" runat="server" Text="Edit tags" CssClass="btn btn-secondary" Font-Bold="True" OnClick="btnTag_Click" />
    </div>

    <%-- EDIT PICTURES --%>

    <asp:Panel ID="pnlEditImages" runat="server" CssClass="d-flex justify-content-center" Visible="false">
        <asp:Repeater ID="rptDeleteImage" runat="server">
            <HeaderTemplate>
                <table class="table-striped" id="" style="width: 450px">
                    <thead>
                        <tr>
                            <th scope="col">Pick a picture to delete</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src="<%#Eval(nameof(rwaLib.Models.ApartmentPicture.Path))%>" style="width: 400px;" />
                        <asp:Button Text="DELETE" runat="server" ID="btnDeleteImageChose" CommandName="<%# Eval(nameof(rwaLib.Models.ApartmentPicture.Path))%>" CommandArgument="<%# Eval(nameof(rwaLib.Models.ApartmentPicture.Id))%>" OnClick="btnDeleteImageChose_Click" CssClass="btn btn-danger" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <%-- EDIT PICTURE MODAL FOR DELETE --%>

    <asp:Panel runat="server" ID="pnlImageDelete" Visible="false">
        <div class="modal" tabindex="-1" role="dialog" style="display: block">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Delete this image?</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="remove()">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure that you want to delete this image?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDeleteImage" Text="DELETE" runat="server" CssClass="btn btn-danger" OnClick="btnDeleteImage_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="remove()">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <%-- ADDING NEW PICS --%>
    <asp:Panel runat="server" ID="pnlAddNewPicture">
        <div class="d-flex justify-content-center mt-2">
                 <label>Upload a new picture:</label>
         </div>
        <div class="d-flex justify-content-center mt-2">
            <div>
                <asp:FileUpload ID="FileUpload" runat="server" accept=".png,.jpg,.jpeg" CssClass="btn"/>
            </div>
        </div>
            <div class="d-flex justify-content-center mt-2">
                <asp:Button ID="btnChooseFile" Text="Add picture" runat="server" CssClass="btn btn-success" OnClick="btnChooseFile_Click"/>
            </div>
    </asp:Panel>


    <%-- CHANGE REPRESENTATIVE PANEL --%>

    <asp:Panel ID="pnlRepresentativePictures" runat="server" CssClass="d-flex justify-content-center" Visible="false">
        <asp:Repeater ID="rptRepresentativePictures" runat="server">
            <HeaderTemplate>
                <table class="table-striped" id="" style="width: 450px">
                    <thead>
                        <tr>
                            <th scope="col">Pick a new representative picture:</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src="<%#Eval(nameof(rwaLib.Models.ApartmentPicture.Path))%>" style="width: 400px;" />
                        <asp:LinkButton OnClick="lbRepresentativeChange_Click" CommandArgument="<%# Eval(nameof(rwaLib.Models.ApartmentPicture.Id)) %>" ID="lbRepresentativeChange" runat="server">Pick</asp:LinkButton>

                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>


    <%-- TAGS + DELETE --%>
    <asp:Panel ID="pnlTags" runat="server" Visible="false" CssClass="table d-flex justify-content-center">
        <asp:Repeater ID="rptTags" runat="server">
            <HeaderTemplate>
                <table class="table-striped" id="" style="width: 450px">
                    <thead>
                        <tr>
                            <th scope="col">Tag type</th>
                            <th scope="col">Tag name</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval(nameof(rwaLib.Models.Tags.TypeNameEng))%></td>
                    <td><%#Eval(nameof(rwaLib.Models.Tags.NameEng))%></td>
                    <td>
                        <asp:Button ID="btnAreYouSure" Text="DELETE" runat="server" CssClass="btn btn-danger" OnClick="btnAreYouSure_Click" CommandArgument="<%# Eval(nameof(rwaLib.Models.Tags.Id)) %>" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
    <%-- ADD TAGS --%>
    <asp:Panel ID="pnlButtonAddTag" runat="server">
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnAddTag" Text="Add tag" runat="server" CssClass="btn btn-success" Font-Bold="true" OnClick="btnAddTag_Click" />
        </div>
    </asp:Panel>


    <%-- PICK TAG TO ADD --%>

    <asp:Panel ID="pnlPickNewTag" runat="server" Visible="true" CssClass="table d-flex justify-content-center">
        <asp:Repeater ID="rptPickNewTag" runat="server">
            <HeaderTemplate>
                <table class="table-striped" id="myTable" style="width: 450px">
                    <thead>
                        <tr>
                            <th scope="col">Tag type</th>
                            <th scope="col">Tag name</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval(nameof(rwaLib.Models.Tags.TypeNameEng))%></td>
                    <td><%#Eval(nameof(rwaLib.Models.Tags.NameEng))%></td>
                    <td>
                        <asp:Button ID="btnPickTag" Text="ADD" runat="server" CssClass="btn btn-success" OnClick="btnPickTag_Click" CommandArgument="<%# Eval(nameof(rwaLib.Models.Tags.Id)) %>" /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <%-- MODAL TAG --%>
    <asp:Panel runat="server" ID="pnlModal" Visible="false">
        <div class="modal" tabindex="-1" role="dialog" style="display: block">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Delete this tag?</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="remove()">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure that you want to delete this tag?</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDeleteTag" Text="DELETE" runat="server" CssClass="btn btn-danger" OnClick="btnDeleteTag_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="remove()">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

 



    <script src="Scripts/ImageGalery.js"></script>

    <script>
        $(document).ready(function () {
            var table = $('#myTable').DataTable({
                pageLength: 5,
                lengthMenu: [[5, 10, 20, -1], [5, 10, 20, 'Todos']]
            })
        });
    </script>

    <script>
        function remove() {
            $('.modal').hide();
        }
        //$("#lnkAttachSOW").click(function () {
        //    $("#FileUpload").click();
        //});
    </script>
 

</asp:Content>

