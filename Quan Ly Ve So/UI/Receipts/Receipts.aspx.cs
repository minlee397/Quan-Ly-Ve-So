using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DAL;
using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI.Receipts
{
    public partial class Receipts : System.Web.UI.Page
    {
        private ReceiptsBL RBL = new ReceiptsBL();
        StringBuilder table;
        Literal content;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uploadData();
                uploadData_not_receipts();
                BindData();
            }
        }

        public void BindData()
        {
            list_Id_Indebtedness.Items.Add(new ListItem("Chọn mã nợ", "mano"));
            list_Id_Indebtedness.DataSource = RBL.IndebtednessList();
            list_Id_Indebtedness.DataValueField = "ID_IND";
            list_Id_Indebtedness.DataTextField = "ID_IND";
            list_Id_Indebtedness.DataBind();
            ConnectDB.con.Close();
        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }

        public void uploadData()
        {
            table_receipts.Controls.Remove(content);
            SqlDataReader rd = RBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã phiếu thu</th><th>Loại vé số</th><th>Mã đại lý</th><th>Ngày nợ</th><th>Ngày trả</th><th>Số tiền</th><th>Xem</th><th>Xóa</th><th>In</th>");
            table.Append("</tr>");

            int i = 1;
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + i + "</td>");
                    table.Append("<td>" + rd[0] + "</td>");
                    table.Append("<td>" + rd[1] + "</td>");
                    table.Append("<td>" + rd[2] + "</td>");

                    string[] date_ind = rd[3].ToString().Split(' ');
                    string[] date_receipt = rd[4].ToString().Split(' ');

                    table.Append("<td>" + date_ind[0] + "</td>");
                    table.Append("<td>" + date_receipt[0] + "</td>");
                    table.Append("<td>" + string.Format("{0:0,0}", rd[5]) + " VNĐ</td>");

                    table.Append("<td>");
                    table.Append("<a href='' data-toggle='modal' data-target='#" + rd[0] + "'><i class='fa fa-eye'></i></a>");

                    // View Row
                    table.Append("<div id='" + rd[0] + "' class='modal fade' role='dialog'>");

                    table.Append("<div class='modal-dialog'>");
                    table.Append("<div class='modal-content'>");
                    table.Append("<div class='modal-header'>");
                    table.Append("<button type = 'button' class='close' data-dismiss='modal'>&times;</button>");
                    table.Append("<h4 class='modal-title custom'>Xem chi tiết mã " + rd[0] + "</h4>");
                    table.Append("</div>");
                    table.Append("<div class='modal-body'>");
                    table.Append("<div class='row'>");

                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Loại vé số: </span>" + rd[1] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đại lý: </span>" + rd[2] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Ngày nợ: </span>" + date_ind[0] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Số tiền: </span>" + string.Format("{0:0,0}", rd[5]) + " VNĐ</div></div>");
                    table.Append("</div>");


                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đài: </span>" + rd[7] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đại lý: </span>" + rd[6] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Ngày trả: </span>" + date_receipt[0] + "</div></div>");
                    table.Append("</div>");



                    table.Append("</div>");
                    table.Append("</div>");
                    table.Append("<div class='modal-footer'>");
                    table.Append("<button type='button' class='btn btn-danger' data-dismiss='modal'>Đóng</button>");
                    table.Append("</div>");
                    table.Append("</div>");
                    table.Append("</div>");

                    table.Append("</div>");

                    table.Append("</td>");
                    table.Append("<td><a href='./Delete_Receipts?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
                    table.Append("<td><a href=''><i class='fa fa-print'></i></a></td>");
                    table.Append("</tr>");
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_receipts.Controls.Add(content);
            ConnectDB.con.Close();
        }

        public void uploadData_not_receipts()
        {
            table_indebtedness.Controls.Remove(content);
            SqlDataReader rd = RBL.Load_not_receipts();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã nợ</th><th>Loại vé số</th><th>Mã đại lý</th><th>Ngày nợ</th><th>Số tiền nợ</th><th>Xem</th>");
            table.Append("</tr>");

            int i = 1;
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + i + "</td>");
                    table.Append("<td>" + rd[0] + "</td>");
                    table.Append("<td>" + rd[1] + "</td>");
                    table.Append("<td>" + rd[2] + "</td>");

                    string[] date_ind = rd[3].ToString().Split(' ');                    

                    table.Append("<td>" + date_ind[0] + "</td>");                    
                    table.Append("<td>" + string.Format("{0:0,0}", rd[4]) + " VNĐ</td>");

                    table.Append("<td>");
                    table.Append("<a href='' data-toggle='modal' data-target='#" + rd[0] + "'><i class='fa fa-eye'></i></a>");
                    
                    // View Row
                    table.Append("<div id='" + rd[0] + "' class='modal fade' role='dialog'>");

                    table.Append("<div class='modal-dialog'>");
                    table.Append("<div class='modal-content'>");
                    table.Append("<div class='modal-header'>");
                    table.Append("<button type = 'button' class='close' data-dismiss='modal'>&times;</button>");
                    table.Append("<h4 class='modal-title custom'>Xem chi tiết mã " + rd[0] + "</h4>");
                    table.Append("</div>");
                    table.Append("<div class='modal-body'>");
                    table.Append("<div class='row'>");

                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Loại vé số: </span>" + rd[1] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đại lý: </span>" + rd[2] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Số tiền: </span>" + string.Format("{0:0,0}", rd[4]) + " VNĐ</div></div>");
                    table.Append("</div>");


                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đài: </span>" + rd[6] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đại lý: </span>" + rd[5] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Ngày nợ: </span>" + date_ind[0] + "</div></div>");
                    table.Append("</div>");



                    table.Append("</div>");
                    table.Append("</div>");
                    table.Append("<div class='modal-footer'>");
                    table.Append("<button type='button' class='btn btn-danger' data-dismiss='modal'>Đóng</button>");
                    table.Append("</div>");
                    table.Append("</div>");
                    table.Append("</div>");

                    table.Append("</div>");

                    table.Append("</td>");
                   
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_indebtedness.Controls.Add(content);
            ConnectDB.con.Close();
        }

        protected void function_insert_Click(object sender, EventArgs e)
        {
            ReceiptsDTO RTO = new ReceiptsDTO();

            RTO.ID_TYPE = input_Id_Type.Text;
            RTO.ID_AGENCY = input_Id_Agency.Text;

            string[] date_ind  = input_Date_Ind.Text.Split('/');
            string[] date_receipts = input_Date_Receipts.Text.Split('/');            

            RTO.DATE_IND = date_ind[1] + "/" + date_ind[0] + "/" + date_ind[2];
            RTO.DATE_RECEIPTS = date_receipts[1] + "/" + date_receipts[0] + "/" + date_receipts[2];
            RTO.PAYMENT = float.Parse(input_Payment.Text);

            
            if (RBL.Insert(RTO) == true)
            {
                MessageBox("Thêm thành công", "Receipts.aspx");
                uploadData();
            }
            else
            {
                MessageBox("Lỗi hệ thống", "Receipts.aspx");
                uploadData();
            }           
        }

        protected void list_Id_Indebtedness_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_indebtedness = list_Id_Indebtedness.SelectedValue;
            DataTable rd = RBL.find_Indebtedness(id_indebtedness);

            input_Id_Type.Text = rd.Rows[0][1].ToString();
            input_Id_Agency.Text = rd.Rows[0][2].ToString();
            input_Payment.Text =  rd.Rows[0][4].ToString();

            string[] date = rd.Rows[0][3].ToString().Split(' ');

            input_Date_Ind.Text = date[0];
            input_Date_Receipts.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}