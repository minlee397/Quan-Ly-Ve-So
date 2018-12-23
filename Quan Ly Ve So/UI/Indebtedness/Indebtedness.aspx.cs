using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI.Indebtedness
{
    public partial class Indebtedness : System.Web.UI.Page
    {
        private IndebtednessBL IBL = new IndebtednessBL();
        StringBuilder table;
        Literal content;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Loadinfo();
                uploadData();
            }
        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }

        public void Loadinfo()
        {
            Search_by.Items.Add(new ListItem("Xin hãy chọn để tìm", "NONE"));
            Search_by.Items.Add(new ListItem("Mã đại lý", "ID_AGENCY"));
            Search_by.Items.Add(new ListItem("Mã Loại vé số", "ID_TYPE"));
            Search_by.Items.Add(new ListItem("Tên đại lý", "NAME_AGENCY"));
            Search_by.Items.Add(new ListItem("Kênh", "CHANNEL"));
        }

        public void uploadData()
        {
            table_indebtedness.Controls.Remove(content);
            SqlDataReader rd = IBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã Nợ</th><th>Loại vé số</th><th>Đại lý</th><th>Ngày nợ</th><th>Số tiền</th><th>View</th>");
            table.Append("</tr>");

            int i = 0;          
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + (i+1) + "</td>");
                    table.Append("<td>" + rd[0] + "</td>");
                    table.Append("<td>" + rd[1] + "</td>");
                    table.Append("<td>" + rd[2] + "</td>");

                    string[] date = rd[3].ToString().Split(' ');

                    table.Append("<td>" + date[0] + "</td>");
                    
                    table.Append("<td>" + string.Format("{0:0,0}", rd[4]) + " VNĐ</td>");
                    table.Append("<td>");
                    table.Append("<a href='' data-toggle='modal' data-target='#" + rd[0] + "'><i class='fa fa-eye'></i></a>");
                    table.Append("<div id='" + rd[0] + "' class='modal fade' role='dialog'>");

                    table.Append("<div class='modal-dialog'>");
                    table.Append("<div class='modal-content'>");
                    table.Append("<div class='modal-header'>");
                    table.Append("<button type = 'button' class='close' data-dismiss='modal'>&times;</button>");
                    table.Append("<h4 class='modal-title custom'>Xem chi tiết</h4>");
                    table.Append("</div>");
                    table.Append("<div class='modal-body'>");
                    table.Append("<div class='row'>");

                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đài: </span>" + rd[0] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đại lý: </span>" + rd[1] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Ngày nợ: </span>" + date[0] + "</div></div>");                    
                    table.Append("</div>");


                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đài: </span>" + rd[5] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đại lý: </span>" + rd[6] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Số tiền nợ: </span>" + string.Format("{0:0,0}", rd[4]) + " VNĐ</div></div>");                    
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
                    table.Append("</td>");
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_indebtedness.Controls.Add(content);
            ConnectDB.con.Close();
        }

        protected void button_find_Click(object sender, EventArgs e)
        {
            table_indebtedness.Controls.Remove(content);
            string search_by = Search_by.SelectedValue;
            string value = input_search.Text;

            if (search_by == "NONE")
                MessageBox("Bạn chưa chọn tìm theo", "Indebtedness.aspx");            
            else
            {
                DataTable rd = IBL.Find(search_by, value);
                table = new StringBuilder();
                table.Append("<table class='table table-hover'");
                table.Append("<tr>");
                table.Append("<th>STT</th><th>Mã Nợ</th><th>Loại vé số</th><th>Đại lý</th><th>Ngày nợ</th><th>Số tiền</th><th>View</th>");
                table.Append("</tr>");

                for (int i = 0; i < rd.Rows.Count; i++)
                {
                    table.Append("<tr>");
                    table.Append("<td>" + (i + 1) + "</td>");
                    table.Append("<td>" + rd.Rows[i][0] + "</td>");
                    table.Append("<td>" + rd.Rows[i][1] + "</td>");
                    table.Append("<td>" + rd.Rows[i][2] + "</td>");

                    string[] date = rd.Rows[i][3].ToString().Split(' ');

                    table.Append("<td>" + date[0] + "</td>");

                    table.Append("<td>" + rd.Rows[i][4] + "</td>");
                    table.Append("<td>");
                    table.Append("<a href='' data-toggle='modal' data-target='#" + rd.Rows[i][0] + "'><i class='fa fa-eye'></i></a>");
                    table.Append("<div id='" + rd.Rows[i][0] + "' class='modal fade' role='dialog'>");

                    table.Append("<div class='modal-dialog'>");
                    table.Append("<div class='modal-content'>");
                    table.Append("<div class='modal-header'>");
                    table.Append("<button type = 'button' class='close' data-dismiss='modal'>&times;</button>");
                    table.Append("<h4 class='modal-title custom'>Xem chi tiết</h4>");
                    table.Append("</div>");
                    table.Append("<div class='modal-body'>");
                    table.Append("<div class='row'>");

                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đài: </span>" + rd.Rows[i][0] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đại lý: </span>" + rd.Rows[i][1] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Ngày nợ: </span>" + date[0] + "</div></div>");
                    table.Append("</div>");


                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đài: </span>" + rd.Rows[i][5] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đại lý: </span>" + rd.Rows[i][6] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Số tiền nợ: </span>" + string.Format("{0:0,0}", rd.Rows[i][4]) + " VNĐ </div></div>");
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
                    table.Append("</td>");

                }

                table.Append("</table>");
                content = new Literal { Text = table.ToString() };
                table_indebtedness.Controls.Add(content);
                ConnectDB.con.Close();
            }
        }
    }
}