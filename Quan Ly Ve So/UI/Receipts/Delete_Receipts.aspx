﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete_Receipts.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Receipts.Delete_Receipts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 type_deal">        
        <div class="row delete">
            <div class="col-sm-7 delete_content">
                <div class="row delete_header">
                    <div class="col-sm-5"><h2>Xóa</h2></div>
                </div>
                <div class ="row delete_body">
                    <div class="col-sm-12">Bạn có chắc chắn xóa không ?</div>                    
                </div>
                <div class="row delete_footer">
                    <div class="col-sm-12">
                        <asp:Button ID="btn_delete" CssClass="btn btn-danger" runat="server" Text="Xóa" OnClick="btn_delete_Click" />                        
                        <a href="Receipts.aspx" class="btn btn-default">Trở về</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
