<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_SignUp_Lottery.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Edit_SignUp_Lottery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 signup_lottery">
        <div class="row title_table">
            <div class="col-xs-12 title_name_table">Sửa đăng ký</div>
        </div>

        <div class="row form-horizontal">
            <div class="form-group">               
                <asp:Label ID="Id_Sign" runat="server" Text="Mã đăng ký: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_id_sign" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">               
                <asp:Label ID="Id_Agency" runat="server" Text="Mã đại lý: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:DropDownList ID="input_id_agency" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">               
                <asp:Label ID="Date_Sign" runat="server" Text="Ngày đăng ký: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_date_sign" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="input_date_sign" Format="dd/MM/yyyy" />
                </div>
            </div>
            <div class="form-group">               
                <asp:Label ID="Quantity" runat="server" Text="Số lượng: " CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_quantity" runat="server" CssClass="form-control" ></asp:TextBox>
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
