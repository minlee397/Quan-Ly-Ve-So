<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prize.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Prize.Prize" %>
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
                                        <asp:Label ID="Name_prize" runat="server" Text="Tên Loại Giải Thưởng: " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_Name_prize" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>                                       
                                    </div>  
                                    <div class="form-group">                                        
                                        <asp:Label ID="Reward" runat="server" Text="Tiền thưởng: " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_Reward" runat="server" CssClass="form-control"></asp:TextBox>
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
                <asp:PlaceHolder ID="table_prize" runat="server"></asp:PlaceHolder>
            </div>          
        </div>
    </div>     
</asp:Content>
