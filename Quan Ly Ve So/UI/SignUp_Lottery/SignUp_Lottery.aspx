<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp_Lottery.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.SignUp_Lottery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 type_lottery">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">Đăng kí vé số</div>
            <div class="col-xs-2">
                <a class="btn btn-danger" data-toggle="modal" data-target="#box_insert_lottery">Thêm Mới</a>
                <div id="box_insert_lottery" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">                        
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title custom">Thêm đăng kí vé số</h4>
                            </div>
                            <div class="modal-body">                                
                                <div class="form-horizontal">                                                                        
                                    <div class="form-group">                                        
                                        <asp:Label ID="Id_agency" runat="server" Text="Tên đại lý: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:DropDownList ID="input_Id_agency" runat="server" CssClass="form-control" AppendDataBoundItems="True" AutoPostBack="False"></asp:DropDownList>
                                        </div>                                       
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Id_type" runat="server" Text="Loại vé số: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:DropDownList ID="input_Id_type" runat="server" CssClass="form-control" AppendDataBoundItems="True" AutoPostBack="False"></asp:DropDownList>
                                        </div>                                       
                                    </div>     
                                    <div class="form-group">                                        
                                        <asp:Label ID="Date_sign" runat="server" Text="Ngày đăng kí: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:TextBox ID="input_Date_sign" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="Calendar" runat="server" TargetControlID="input_Date_sign" Format="dd/MM/yyyy" />
                                        </div>                                       
                                    </div>    
                                    <div class="form-group">                                        
                                        <asp:Label ID="Quanity_sign" runat="server" Text="số lượng: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:TextBox ID="input_Quanity_sign" runat="server" CssClass="form-control"></asp:TextBox>
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
