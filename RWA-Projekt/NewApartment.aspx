<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="NewApartment.aspx.cs" Inherits="RWA_Projekt.NewApartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <%-- INFO PANEL --%>
    <asp:Panel runat="server" ID="pnlInfoForm" Visible="true">
        <div class="d-flex justify-content-center">
            <label>Step 1: Apartment info</label>
        </div>
        <div class=" d-flex justify-content-center gap-4 ">

            <div class="py-2">
                <asp:Label runat="server" ID="lblName" Text="Apartment name (HRV): " />
                <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="Step1" ID="rfvName" runat="server" ErrorMessage="Apartment name is empty!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbName" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="py-2">
                <asp:Label runat="server" ID="lblNameEng" Text="Apartment name (ENG): " />
                <asp:TextBox ID="tbNameEng" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="Step1" ID="rfvNameEng" runat="server" ErrorMessage="Apartment name is empty!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbNameEng" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="py-2">
                <asp:Label runat="server" ID="lblAddress" Text="Address:" />
                <asp:TextBox ID="tbAddress" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="Step1" ID="rfvPrice" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbAddress" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="d-flex justify-content-center mt-2 gap-4 align-align-items-center">

            <div>
                <asp:Label runat="server" ID="lblPrice" Text="Price(€):" />
                <asp:TextBox ID="tbPrice" runat="server" Width="70px" CssClass="form-control" TextMode="Number" min="0"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="Step1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbPrice" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div>
                <asp:Label runat="server" ID="lblAdults" Text="Adult rooms:" />
                <asp:TextBox ID="tbAdults" runat="server" Width="70px" CssClass="form-control" TextMode="Number" min="0"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="Step1" ID="rfvAdults" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbAdults" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div>
                <asp:Label runat="server" ID="lblChildren" Text="Children rooms:" />
                <asp:TextBox ID="tbChildren" runat="server" Width="70px" CssClass="form-control" TextMode="Number" min="0"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="Step1" ID="rfvChildren" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbChildren" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div>
                <asp:Label runat="server" ID="lblRooms" Text="Total rooms:" />
                <asp:TextBox ID="tbRooms" runat="server" Width="70px" CssClass="form-control" TextMode="Number" min="0"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="Step1" ID="rfvRooms" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbRooms" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
            <div>
                <asp:Label runat="server" ID="Label7" Text="Beach distance: " />
                <asp:TextBox ValidationGroup="Step1" ID="tbBeachDistance" runat="server" Width="70px" CssClass="form-control" TextMode="Number" min="0"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="Step1" ID="rfvBeach" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbBeachDistance" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class=" d-flex justify-content-center gap-4 ">

            <div class="py-2">
                <asp:Label runat="server" ID="lblCity" Text="City:" />
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
            </div>


            <div class="py-2">
                <asp:Label runat="server" ID="lblOwner" Text="Apartment owner: " />
                <asp:DropDownList ID="ddlOwner" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="d-flex justify-content-center">
            <asp:Button Text="ADD" runat="server" ID="btnAddNewApartment" CssClass="btn btn-success" ValidationGroup="Step1" OnClick="btnAddNewApartment_Click" />
        </div>
    </asp:Panel>


    <%-- TAGS + DELETE --%>
    <asp:Panel ID="pnlTags" runat="server" Visible="false" CssClass="table d-flex justify-content-center">
        <div class="d-flex justify-content-center">
            <label>Step 2: Tags</label>
            <br />
        </div>
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
                        <asp:Button ID="btnAreYouSure" Text="DELETE" OnClick="btnAreYouSure_Click" runat="server" CssClass="btn btn-danger" CommandArgument="<%# Eval(nameof(rwaLib.Models.Tags.Id)) %>" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>




    <%-- PICK TAG TO ADD --%>

    <asp:Panel ID="pnlPickNewTag" runat="server" Visible="false" CssClass="table d-flex justify-content-center">
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
                        <asp:Button ID="btnPickTag" OnClick="btnPickTag_Click" Text="ADD" runat="server" CssClass="btn btn-success" CommandArgument="<%# Eval(nameof(rwaLib.Models.Tags.Id)) %>" /></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>

    <div class="d-flex justify-content-center mt-2">
        <asp:Button ID="finishAddingTags" OnClick="finishAddingTags_Click" Text="FINISH ADDING TAGS" runat="server" CssClass="btn btn-success" />
    </div>




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

    <%-- PICTURES --%>
    <asp:Panel runat="server" ID="pnlAddNewPicture">
        <div class="d-flex justify-content-center">
            <label>Step 3: Pictures</label>
        </div>
        <div class="d-flex justify-content-center mt-2">
            <label>Upload a new picture:</label>
        </div>
        <div class="d-flex justify-content-center mt-2">
            <div>
                <asp:FileUpload ID="FileUpload" runat="server" accept=".png,.jpg,.jpeg" CssClass="btn" />
            </div>
        </div>
        <div class="d-flex justify-content-center mt-2">
            <asp:Button ID="btnChooseFile" Text="Add picture" runat="server" CssClass="btn btn-success" OnClick="btnChooseFile_Click" />
        </div>
    </asp:Panel>

    <%-- DISPLAY PICTURES --%>
    <div class="d-flex justify-content-center flex-column mt-2">
        <asp:Repeater ID="rptImgs" runat="server">
            <ItemTemplate>
                <div class="d-flex justify-content-center mt-1">
                    <img src="<%# Eval(nameof(rwaLib.Models.ApartmentPicture.Path)) %>" style="width: 300px; height: 300px">
                </div>
                <div class="d-flex justify-content-center">
                    <asp:Button Text="REPRESENTATIVE" runat="server" ID="pickRepresentative" CssClass="btn btn-primary d-flex justify-content-center mt-1 mb-2" OnClick="pickRepresentative_Click" CommandArgument="<%# Eval(nameof(rwaLib.Models.ApartmentPicture.Id)) %>" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <asp:Panel runat="server" ID="pnlFinish">
        <div class="d-flex justify-content-center mt-2">
            <asp:Button Text="FINISH" runat="server" ID="finish" OnClick="finish_Click" CssClass="btn btn-success" />
        </div>
    </asp:Panel>

    <script>
        function remove() {
            $('.modal').hide();
        }
    </script>
</asp:Content>
