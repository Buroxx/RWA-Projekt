<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AdministratorTags.aspx.cs" Inherits="RWA_Projekt.AdministratorTags" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <style>
        .tablica {
            border-top: none;
            border-bottom: none;
            line-height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <asp:GridView ID="gvTags" CssClass="table d-flex justify-content-center mt-2 tablica" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="Category" DataField="TypeNameEng" />
            <asp:BoundField HeaderText="Tag" DataField="NameEng" />
            <asp:BoundField HeaderText="Usage" DataField="Usage" />
            <asp:BoundField HeaderText="" DataField="" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDeleteModal" runat="server" Visible='<%# Convert.ToInt32(Eval("Usage")) == 0 %>' Text="DELETE" OnClick="btnDeleteModal_Click" CssClass="btn btn-danger" CommandArgument="<%# Eval(nameof(rwaLib.Models.Tags.Id)) %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="d-flex justify-content-center">
        <asp:Button Text="ADD NEW TAG" runat="server" CssClass="btn btn-success" ID="btnAddNewTagPanel" OnClick="btnAddNewTagPanel_Click" />
    </div>


    <asp:Panel ID="pnlAddNewTag" runat="server" Visible="false" CssClass="d-flex justify-content-center gap-4">
        <div>
            <asp:Label runat="server" ID="lblCategory" Text="Category: " />
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
        </div>
        <div>
            <asp:Label runat="server" ID="lblTagName" Text="Tag name hrv:" />
            <asp:TextBox ID="tbTagNameHrv" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNameHrv" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbTagNameHrv" Display="Dynamic" ValidationGroup="AddNewTag"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label runat="server" ID="Label1" Text="Tag name eng:" />
            <asp:TextBox ID="tbTagNameEng" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNameEng" runat="server" ErrorMessage="Empty field!" Font-Bold="true" ForeColor="Red" ControlToValidate="tbTagNameEng" Display="Dynamic" ValidationGroup="AddNewTag"></asp:RequiredFieldValidator>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="pnlAlreadyExists" Visible="false" CssClass="mt-2">
        <div class="alert alert-danger d-flex justify-content-center" role="alert">
            Tag already exists!
        </div>
    </asp:Panel>



    <div class="d-flex justify-content-center mt-2">
        <asp:Button Text="ADD NEW TAG" runat="server" CssClass="btn btn-success" ID="btnAddNewTag" OnClick="btnAddNewTag_Click" Visible="false" ValidationGroup="AddNewTag" />
    </div>


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




    <script>
        function remove() {
            $('.modal').hide();
        }
    </script>

</asp:Content>
