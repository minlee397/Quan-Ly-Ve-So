<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_Deal.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Edit_Deal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 type_deal">
        <div class="row title_table">
            <div class="col-xs-12 title_name_table">Sửa đợt phát hành</div>
        </div>

        <div class="row form-horizontal">
            <div class="form-group">
                <asp:Label ID="Type" runat="server" Text="Mã Đài: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_Type" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Agency" runat="server" Text="Mã Đại Lý: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_Agency" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="QuantityReceive" runat="server" Text="Số lượng nhận: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_QuantityReceive" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="QuantitySell" runat="server" Text="Số lượng bán: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_QuantitySell" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="DateReceive" runat="server" Text="Ngày nhận: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_DateReceive" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="input_DateReceive" Format="dd/MM/yyyy" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Commission" runat="server" Text="Hoa hồng: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_Commission" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btn_edit" runat="server" CssClass="btn btn-danger" Text="Sửa" OnClick="btn_edit_Click" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
