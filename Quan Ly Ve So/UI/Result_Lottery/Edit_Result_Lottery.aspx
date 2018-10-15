<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_Result_Lottery.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Result_Lottery.Edit_Result_Lottery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 type_lottery">
        <div class="row title_table">
            <div class="col-xs-12 title_name_table">Sửa kết quả xổ số</div>
        </div>

        <div class="row form-horizontal">
            <div class="form-group">               
                <asp:Label ID="Id_result" runat="server" Text="Mã kết quả: " CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_Id_result" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">               
                <asp:Label ID="Id_type" runat="server" Text="Mã Đài: " CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-6">
                    <asp:DropDownList ID="input_Id_type" runat="server" CssClass="form-control"></asp:DropDownList>                                        
                </div>
            </div> 
            <div class="form-group">               
                <asp:Label ID="Id_prize" runat="server" Text="Mã giải: " CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-6">    
                    <asp:DropDownList ID="input_Id_prize" runat="server" CssClass="form-control"></asp:DropDownList>                    
                </div>
            </div> 
            <div class="form-group">               
                <asp:Label ID="Date_result" runat="server" Text="Ngày xổ: " CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_Date_result" runat="server" CssClass="form-control" ></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="input_Date_result" Format="dd/MM/yyyy" />
                </div>
            </div> 
            <div class="form-group">               
                <asp:Label ID="Number_win" runat="server" Text="Số trúng: " CssClass="control-label col-sm-3"></asp:Label>
                <div class="col-sm-6">                    
                    <asp:TextBox ID="input_Number_win" runat="server" CssClass="form-control" ></asp:TextBox>
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
