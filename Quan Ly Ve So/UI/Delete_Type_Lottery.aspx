﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete_Type_Lottery.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Delete_Type_Lottery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 type_lottery">        
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
                        <a href="Type_Lottery.aspx" class="btn btn-default">Trở về</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
