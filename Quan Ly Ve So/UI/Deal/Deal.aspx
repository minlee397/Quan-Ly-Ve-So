<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Deal.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Deal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">     
    <div class="col-sm-12 deal">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">Đợt phát hành</div>
            <div class="col-xs-2">
                <a class="btn btn-danger" data-toggle="modal" data-target="#box_insert_deal">Thêm Mới</a>
                <div id="box_insert_deal" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content"> 
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>                       
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title custom">Thêm đợt</h4>
                            </div>                                                        
                            <div class="modal-body">                                
                                <div class="form-horizontal">                                                                        
                                    <div class="form-group">
                                        <asp:Label ID="Type" runat="server" Text="Mã Đài: " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </div> 
                                    </div>                                    
                                    <div class="form-group">                                        
                                        <asp:Label ID="Agency" runat="server" Text="Mã Đại Lý: " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                                <asp:DropDownList ID="ddlAgency" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAgency_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True"></asp:DropDownList>
                                        </div>                                        
                                    </div>                                            
                                    <div class="form-group">                                        
                                        <asp:Label ID="Quantity_Receive" runat="server" Text="Số lượng nhận: " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                                <asp:TextBox ID="input_QuantityReceive" runat="server" CssClass="form-control" ></asp:TextBox>
                                        </div> 
                                    </div>
                                        
                                    <div class="form-group">                                        
                                        <asp:Label ID="Quantity_Sell" runat="server" Text="Số lượng bán: " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                                <asp:TextBox ID="input_QuantitySell" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="DateReceive" runat="server" Text="Ngày nhận: " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">                                             
                                                <asp:TextBox ID="input_DateReceive" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Commission" runat="server" Text="Hoa hồng: (Tính theo %)" CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:TextBox ID="input_Commission" runat="server" CssClass="form-control" Text="10%"></asp:TextBox>
                                        </div> 
                                    </div>
                                    <div id="error_sentence" class="form-group box_error" runat="server" style="display:none;">                                        
                                        <asp:Label ID="error_input_QuantityReceive" runat="server" CssClass="col-sm-12 col-lg-12 error_style"></asp:Label>
                                    </div>
                                    <div id="cal_QuantityReceive" class="form-group" runat="server" style="border-top:1px solid #d4d1d1; display:none">                                        
                                        <div class="col-sm-12 col-lg-12">
                                            <div class="row" style="padding-top:3%;">
                                                <asp:Label ID="title_batch" CssClass="col-sm-12 title_batch" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 col-lg-12">
                                                    <asp:PlaceHolder ID="table_batch" runat="server"></asp:PlaceHolder>
                                                </div>                                                    
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-3 col-lg-3">
                                                    Công thức tính: 
                                                </div> 
                                                <div class="col-sm-9 col-lg-9">
                                                    <asp:Label ID="cal_quantity" CssClass="cal_quantity" runat="server" Text=""></asp:Label>
                                                </div>                                                   
                                            </div>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>                            
                            <div class="modal-footer">
                                <asp:Button ID="function_insert" runat="server" Text="Thêm" CssClass="btn btn-danger" OnClick="function_insert_Click" Enabled="True" />
                            </div>
                            </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlAgency" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
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
                <asp:PlaceHolder ID="table_deal" runat="server"></asp:PlaceHolder>
            </div>          
        </div>
    </div>     
</asp:Content>
