<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result_Lottery.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Result_Lottery.Result_Lottery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 type_lottery">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">Kết quả xổ số</div>
            <div class="col-xs-2">
                <a class="btn btn-danger" data-toggle="modal" data-target="#box_insert_lottery">Thêm Mới</a>
                <div id="box_insert_lottery" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">                        
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title custom">Thêm kết quả xổ số</h4>
                            </div>
                            <div class="modal-body">                                
                                <div class="form-horizontal">                                                                        
                                    <div class="form-group">                                        
                                        <asp:Label ID="Id_type" runat="server" Text="Mã Đài: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">                                             
                                            <asp:DropDownList ID="input_Id_type" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>                                       
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Id_prize" runat="server" Text="Mã loại giải: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:DropDownList ID="input_Id_prize" runat="server" CssClass="form-control"></asp:DropDownList>                                            
                                        </div>                                       
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Date_result" runat="server" Text="Ngày xổ: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_Date_result" runat="server" CssClass="form-control"></asp:TextBox>
                                             <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="input_Date_result"/>                                             
                                        </div>                                        
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Number_win" runat="server" Text="Số trúng: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_Number_win" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>                                       
                                    </div>                                                                   
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="function_insert" runat="server" Text="Thêm" CssClass="btn btn-danger" OnClick="function_insert_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                               
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12 table-responsive">
                <asp:PlaceHolder ID="table_lottery" runat="server"></asp:PlaceHolder>
            </div>          
        </div>
    </div>     
</asp:Content>
