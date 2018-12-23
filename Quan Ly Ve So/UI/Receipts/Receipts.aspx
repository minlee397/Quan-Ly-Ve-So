<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receipts.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Receipts.Receipts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 deal">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">Phiếu Thu</div>
            <div class="col-xs-2">
                <a class="btn btn-danger" data-toggle="modal" data-target="#box_insert_deal">Thêm Mới</a>
                <div id="box_insert_deal" class="modal fade" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content"> 
                                                   
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title custom">Thêm phiếu thu</h4>
                            </div>     
                                                                        
                            <div class="modal-body">                                
                                <div class="form-horizontal">  
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>                                                                          
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group row">                                                
                                                <asp:Label ID="Id_indebtedness" runat="server" Text="Mã nợ" CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                                <div class="col-sm-8 col-lg-8">
                                                    <asp:DropDownList ID="list_Id_Indebtedness" CssClass="form-control" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="list_Id_Indebtedness_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>    
                                                </div>                                                
                                            </div>
                                            <div class="form-group row">                                                
                                                <asp:Label ID="Id_Type" runat="server" Text="Loại vé số" CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                                <div class="col-sm-8 col-lg-8">
                                                    <asp:TextBox ID="input_Id_Type" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>                                                
                                            </div>
                                            <div class="form-group row">                                                
                                                <asp:Label ID="Id_Agency" runat="server" Text="Mã đại lý" CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                                <div class="col-sm-8 col-lg-8">
                                                    <asp:TextBox ID="input_Id_Agency" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>                                                
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">                                                
                                                <asp:Label ID="Payment" runat="server" Text="Số tiền" CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                                <div class="col-sm-8 col-lg-8">
                                                    <asp:TextBox ID="input_Payment" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>                                                
                                            </div>
                                            <div class="form-group row">                                                
                                                <asp:Label ID="Date_Ind" runat="server" Text="Ngày nợ" CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                                <div class="col-sm-8 col-lg-8">
                                                    <asp:TextBox ID="input_Date_Ind" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>                                                
                                            </div>
                                            <div class="form-group row">                                                
                                                <asp:Label ID="Date_Receipts" runat="server" Text="Ngày thanh toán" CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                                <div class="col-sm-8 col-lg-8">
                                                    <asp:TextBox ID="input_Date_Receipts" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                </div>                                                
                                            </div>
                                        </div>
                                    </div>     
                                    <div class="form-group row title_indebtedness">
                                        <div class="col-sm-3 col-lg-3 control-label">Danh sách còn nợ</div>
                                        <asp:Label ID="search_indebtedness" runat="server" Text="Tìm" CssClass="control-label col-sm-2 col-lg-2"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:TextBox ID="input_search_indebtedness" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <button class="btn btn-default"><i class="fa fa-search"></i></button>
                                    </div>
                                    </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="list_Id_Indebtedness" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <div class="row">                                        
                                        <div class="col-sm-12 table-responsive">
                                            <asp:PlaceHolder ID="table_indebtedness" runat="server"></asp:PlaceHolder>
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

        <!--<div class="row box_search">                     
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
                        <asp:Button ID="button_find" runat="server" Text="Tìm" CssClass="btn btn-danger" />                                     
                    </div>
                </div>                                                                   
            </div>            
        </div> -->

        <div class="row table_style">
            <div class="col-sm-12 table-responsive">
                <asp:PlaceHolder ID="table_receipts" runat="server"></asp:PlaceHolder>
            </div>          
        </div>
    </div>
</asp:Content>
