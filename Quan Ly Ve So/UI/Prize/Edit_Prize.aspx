<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_Prize.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Prize.Edit_Prize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 type_lottery">
        <div class="row title_table">
            <div class="col-xs-12 title_name_table">Sửa loại giải thưởng</div>
        </div>

        <div class="row form-horizontal">
            <div class="form-group">               
                <asp:Label ID="Id_prize" runat="server" Text="Mã Loại Giải Thưởng: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_Id_prize" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">               
                <asp:Label ID="Name_prize" runat="server" Text="Tên Loại Giải Thưởng: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_Name_prize" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>  
            <div class="form-group">               
                <asp:Label ID="Reward" runat="server" Text="Tiền thưởng: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_Reward" runat="server" CssClass="form-control" ></asp:TextBox>
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
