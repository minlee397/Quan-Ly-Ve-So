<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Type_Lottery.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Type_Lottery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">     
    <div class="col-sm-12 type_lottery">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">Loại vé số</div> 
            <div class="col-xs-2">
                <a class="btn btn-danger" data-toggle="modal" data-target="#box_insert_lottery">Thêm Mới</a>
                <div id="box_insert_lottery" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">                        
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title custom">Thêm loại vé</h4>
                            </div>
                            <div class="modal-body">                                
                                <div class="form-horizontal">                                                                        
                                    <div class="form-group">                                        
                                        <asp:Label ID="Channel" runat="server" Text="Tên Đài: " CssClass="control-label col-sm-2 col-lg-2"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_Channel" runat="server" CssClass="form-control"></asp:TextBox>
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
        <div class="row box_search">                     
            <div class="form-horizontal">                                                                        
                <div class="form-group">                                        
                    <asp:Label ID="Search" runat="server" Text="Tìm kiếm: " CssClass="control-label col-sm-2 col-lg-2 label_style"></asp:Label>
                    <div class="col-sm-2 col-lg-2">
                        <asp:DropDownList ID="Search_by" runat="server" CssClass="form-control"></asp:DropDownList>  
                    </div>
                    <div class="col-sm-6 col-lg-6">
                        <asp:TextBox ID="input_search" runat="server" CssClass="form-control"></asp:TextBox>                            
                    </div>  
                    <div class="col-sm-2 col-lg-2">
                        <asp:Button ID="button_find" runat="server" Text="Tìm" CssClass="btn btn-danger" OnClick="button_find_Click" />                                     
                    </div>
                </div>                                                                   
            </div>            
        </div>        
        <div class="row table_style">
            <div class="col-sm-12 table-responsive">
                <asp:PlaceHolder ID="table_lottery" runat="server"></asp:PlaceHolder>
            </div>          
        </div>
    </div>     
</asp:Content>
