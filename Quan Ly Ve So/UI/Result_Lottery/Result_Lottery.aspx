<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result_Lottery.aspx.cs" Inherits="Quan_Ly_Ve_So.UI.Result_Lottery.Result_Lottery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12 type_lottery">
        <div class="row title_table">
            <div class="col-xs-4 title_name_table">Dò vé số</div>            
        </div>

        <div class="row">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="col-xs-5">                        
                        <div class="form-horizontal">                                                                        
                            <div class="form-group">                                        
                                <asp:Label ID="winner_number_search" runat="server" Text="Nhập mã số trúng:  " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                <div class="col-sm-7 col-lg-7">                                                                         
                                    <asp:TextBox ID="input_winner_number_search" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>                                       
                            </div>
                            <div class="form-group">                                        
                                <asp:Label ID="id_type_search" runat="server" Text="Chọn đài:  " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                <div class="col-sm-7 col-lg-7">                                             
                                    <asp:DropDownList ID="input_id_type_search" runat="server" CssClass="form-control" AutoPostBack="True" AppendDataBoundItems="True"></asp:DropDownList>
                                </div>                                       
                            </div>
                            <div class="form-group">                                        
                                <asp:Label ID="date_search" runat="server" Text="Chọn Ngày xổ:  " CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                <div class="col-sm-7 col-lg-7">                                             
                                    <asp:TextBox ID="input_date_search" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                                    <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender2" runat="server" TargetControlID="input_date_search"/>
                                </div>                                       
                            </div>
                            <div class="form-group">                                        
                                <asp:Label ID="Label2" runat="server" Text="" CssClass="control-label col-sm-4 col-lg-4"></asp:Label>
                                <div class="col-sm-7 col-lg-7">                                             
                                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-success" Text="Dò số" OnClick="btn_search_Click" />
                                </div>                                       
                            </div>
                            <div class="form-group">                                        
                                <asp:Label ID="error_search" runat="server" Text="" CssClass="control-label col-sm-8 col-lg-8" ForeColor="#CC0000"></asp:Label>                                
                            </div>
                            
                        </div>
                        
                    </div>    
                    <div class="col-xs-7 box_result">
                        <div class='row' style='text-align:center; color:#ffffff; background-color:#cc5151; border-bottom:1px solid #808080; padding-top:1%; font-size:24px; font-weight:bold;'><div class='col-sm-12'>KẾT QUẢ</div></div>                                                 
                        <asp:PlaceHolder ID="table_result_number" runat="server"></asp:PlaceHolder>                                                             
                    </div>
                </ContentTemplate>                
            </asp:UpdatePanel>      
        </div>

        <div class="row title_table">
            <div class="col-xs-4 title_name_table">Danh sách kết quả xổ số</div>
            <div class="col-xs-2">
                <a class="btn btn-danger" data-toggle="modal" data-target="#box_insert_lottery"><i class="fa fa-plus"></i> Thêm Mới</a>
                <div id="box_insert_lottery" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">                        
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title custom">Thêm kết quả xổ số</h4>
                            </div>
                            <div class="modal-body">                                
                                <div class="form-horizontal">                                                                        
                                    <div class="form-group">                                        
                                        <asp:Label ID="Id_type" runat="server" Text="Mã Đài: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">                                             
                                            <asp:DropDownList ID="input_Id_type" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>                                       
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Id_prize" runat="server" Text="Mã loại giải: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                            <asp:DropDownList ID="input_Id_prize" runat="server" CssClass="form-control"></asp:DropDownList>                                            
                                        </div>                                       
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Date_result" runat="server" Text="Ngày xổ: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_Date_result" runat="server" CssClass="form-control"></asp:TextBox>
                                             <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendarExtender1" runat="server" TargetControlID="input_Date_result"/>                                             
                                        </div>                                        
                                    </div>
                                    <div class="form-group">                                        
                                        <asp:Label ID="Number_win" runat="server" Text="Số trúng: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-6 col-lg-6">
                                             <asp:TextBox ID="input_Number_win" runat="server" CssClass="form-control"></asp:TextBox>
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
            <div class="col-xs-1">
                <a class="btn btn-success" data-toggle="modal" data-target="#box_import_result"><i class="fa fa-upload"></i> Import dữ liệu</a>
                <div id="box_import_result" class="modal fade" role="dialog">
                    <div class="modal-dialog">
                        <div class="modal-content">                        
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title custom">Import kết quả xổ số</h4>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            <div class="modal-body">                                
                                <div class="form-horizontal">                                                                        
                                    <div class="form-group">                                        
                                        <asp:Label ID="Label1" runat="server" Text="File Import: " CssClass="control-label col-sm-3 col-lg-3"></asp:Label>
                                        <div class="col-sm-2 col-lg-2">                                            
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="hidden" />                                            
                                            <button type="button" id="btn_select_file" class ="btn btn-danger">Chọn File</button>
                                            <script type="text/javascript">
                                                $(document).ready(function () {
                                                    $('#<%=FileUpload1.ClientID%>').on('change', function (e) {
                                                        $('#<%=file_name.ClientID%>').val(e.target.files[0].name);
                                                        handleFileSelect(e);
                                                        $('#btn_select_file').prop('disabled', true);
                                                        $('#<%=btn_import_data.ClientID%>').prop('disabled', false);
                                                    });

                                                    $('#btn_select_file').click(function () {
                                                        $('#<%=FileUpload1.ClientID%>').click();
                                                    })
                                                })                                                
                                                
                                                function handleFileSelect(evt) {
                                                    var files = evt.target.files; // FileList object                                                    
                                                    for (var i = 0, f; f = files[i]; i++) {
                                                        var reader = new FileReader();
                                                        reader.onload = (function (reader) {
                                                            return function () {                                                                
                                                                var lines = reader.result.split('\n');
                                                                var date_type = lines[0].split('\t');
                                                                $('#info_file_log').html("<strong>Mã đài:</strong> " + date_type[0] + ", <strong>Ngày xổ:</strong> " + date_type[1]);
                                                                var contenttable =""+
                                                                    "<table class='table table-hover'>" +
                                                                        "<tr>"+
                                                                            "<th>STT</th><th>Mã loại giải</th><th>Số trúng</th>";
                                                                        "</tr>";

                                                                    for (var i = 1; i < lines.length; i++)
                                                                    {
                                                                        contenttable += "<tr>";
                                                                        contenttable += "<td>" + (i) + "</td>";
                                                                        var contentlines = lines[i].split('\t');
                                                                        contenttable += "<td>" + contentlines[0] + "</td>";
                                                                        contenttable += "<td>" + contentlines[1] + "</td>";
                                                                        contenttable += "</tr>";
                                                                    }
                                                                    contenttable += "</table";
                                                                    document.getElementById('table_data_result').innerHTML = contenttable;
                                                            }
                                                        })(reader);
                                                        reader.readAsText(f);
                                                    }
                                                }                                                
                                            </script>                                                                                                                
                                        </div>    
                                        <div class="col-sm-5 col-lg-5">
                                            <input id="file_name" runat="server" type="text" readonly="readonly" class="form-control" style="width:50%" /> 
                                        </div>                                                       
                                    </div>                                                                                                                                   
                                </div>
                                <hr />
                                <div class="row">
                                    <span id="info_file_log" class="col-sm-12">                                        
                                    </span>          
                                </div>
                                <div class="row">
                                    <div id="table_data_result" class="col-sm-12 table-responsive">                                        
                                    </div>          
                                </div>                                
                            </div>
                            </ContentTemplate>
                            <Triggers>                                
                            </Triggers>
                            </asp:UpdatePanel>
                            <div class="modal-footer">
                                <a href="Result_Lottery.aspx" class="btn btn-default">Làm lại</a>
                                <asp:Button ID="btn_import_data" runat="server" Text="Import" CssClass="btn btn-danger" OnClick="btn_import_data_Click" Enabled="False" />
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

