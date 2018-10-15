<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deal.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Deal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">     
    <div class="col-sm-12 deal">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">Đợt Phát Hành</div>
            <div class="col-xs-2">
                <a class="btn btn-danger" data-toggle="modal" data-target="#box_insert_deal">Thêm Mới</a>
                <div id="box_insert_deal" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">                        
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title custom">Thêm đợt</h4>
                            </div>
                            <div class="modal-body">                                
                                <div class="form-horizontal">                                                                        
                                    <div class="form-group">
                                        <asp:Label ID="Type" runat="server" Text="Mã Đài: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div> 
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Agency" runat="server" Text="Mã Đại Lý: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:DropDownList ID="ddlAgency" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div> 
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Quantity_Receive" runat="server" Text="Số lượng nhận: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_QuantityReceive" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div> 
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Quantity_Sell" runat="server" Text="Số lượng bán: " CssClass="control-label col-sm-3 col-lg-"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_QuantitySell" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="DateReceive" runat="server" Text="Ngày nhận: " CssClass="control-label col-sm-3 col-lg-"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">                                             
                                             <asp:TextBox ID="input_DateReceive" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Commission" runat="server" Text="Hoa hồng: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_Commission" runat="server" CssClass="form-control"></asp:TextBox>
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
                <asp:PlaceHolder ID="table_deal" runat="server"></asp:PlaceHolder>
            </div>          
        </div>
    </div>     
</asp:Content>
