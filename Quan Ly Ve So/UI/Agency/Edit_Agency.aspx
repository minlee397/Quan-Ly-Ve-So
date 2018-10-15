<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_Agency.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Edit_Agency" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <div class="col-sm-12 type_lottery">
        <div class="row title_table">
            <div class="col-xs-12 title_name_table">
                Sửa đại lý</div>
        </div>
        <div class="row form-horizontal">
            <div class="form-group">
                <asp:Label ID="Id_Agency" runat="server" Text="Mã Đại Lý: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_id" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Name" runat="server" Text="Tên Đại Lý: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_name" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Addr" runat="server" Text="Địa chỉ: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_addr" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Numphone" runat="server" Text="Điện thoại: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">
                    <asp:TextBox ID="input_numphone" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="Activate" runat="server" Text="Tình trạng: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:RadioButtonList ID="rdo_Activate" runat="server" RepeatColumns = "2" RepeatDirection="Vertical" RepeatLayout="Table" CssClass="form-control myrblclass" >
                        <asp:ListItem Value="1" Selected="true">Hoạt động</asp:ListItem>                        
                        <asp:ListItem Value="0">Dừng hoạt động</asp:ListItem>
                    </asp:RadioButtonList>                                       
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
