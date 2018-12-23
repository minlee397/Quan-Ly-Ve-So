<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Indebtedness.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Indebtedness.Indebtedness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 deal">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">
                Công nợ
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

        <div class="row">
            <div class="col-sm-12 table-responsive">
                <asp:PlaceHolder ID="table_indebtedness" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>
