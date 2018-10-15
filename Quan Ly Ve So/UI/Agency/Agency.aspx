<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agency.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Agency" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <div class="col-sm-12 deal">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">
                Đại Lý</div>
            <div class="col-xs-2">
                <a class="btn btn-danger" data-toggle="modal" data-target="#box_insert_deal">Thêm Mới</a>
                <div id="box_insert_deal" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    &times;
                                </button>
                                <h4 class="modal-title custom">Thêm đại lý</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <asp:Label ID="NameAgency" runat="server" Text="Tên Đại Lý: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:TextBox ID="input_NameAgency" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Addr" runat="server" Text="Địa Chỉ: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:TextBox ID="input_Addr" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Numphone" runat="server" Text="Số Điện Thoại: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:TextBox ID="input_Numphone" runat="server" CssClass="form-control"></asp:TextBox>     
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Label ID="Activate" runat="server" Text="Tình Trạng: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:RadioButtonList ID="rdo_Activate" runat="server" CssClass="form-control myrblclass" RepeatColumns = "2" RepeatDirection="Vertical" RepeatLayout="Table" >
                                                <asp:ListItem Value="1" Selected="true">Hoạt động</asp:ListItem>
                                                <asp:ListItem Value="0">Dừng</asp:ListItem>
                                             </asp:RadioButtonList>
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
                <asp:PlaceHolder ID="table_agency" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>

