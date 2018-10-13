using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DAL;
using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI
{
    public partial class Agency : System.Web.UI.Page
    {
        private AgencyBL ABL = new AgencyBL();
        StringBuilder table;
        Literal content;

        protected void Page_Load(object sender, EventArgs e)
        {
            uploadData();
        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }

        public void uploadData()
        {
            table_agency.Controls.Remove(content);
            SqlDataReader rd = ABL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã Đại Lý</th><th>Tên Đại Lý</th><th>Địa Chỉ</th><th>Số Điện Thoại</th><th>Tình Trạng</th><th>Sửa</th><th>Xóa</th>");
            table.Append("</tr>");

            int i = 0;
            string status = "";
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + i + "</td>");
                    table.Append("<td>" + rd[0] + "</td>");
                    table.Append("<td>" + rd[1] + "</td>");
                    table.Append("<td>" + rd[2] + "</td>");
                    table.Append("<td>" + rd[3] + "</td>");
                    if ((int)rd[4] == 1)
                        status = "Hoạt động";
                    else
                        status = "Dừng hoạt động";
                    table.Append("<td>" + status + "</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Agency?edit=" + rd[0] + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>");
                    table.Append("<td><a href='Delete_Agency?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
                    table.Append("</tr>");
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_agency.Controls.Add(content);
            ConnectDB.con.Close();
        }

        protected void function_insert_Click(object sender, EventArgs e)
        {
            AgencyDTO ALO = new AgencyDTO();

            ALO.NAME_AGENCY = input_NameAgency.Text;
            ALO.ADDR = input_Addr.Text;
            ALO.NUMPHONE = input_Numphone.Text;
            ALO.ACTIVATE = Int32.Parse(rdo_Activate.SelectedValue.ToString());
            if (ABL.Insert(ALO) == true)
            {
                MessageBox("Thêm thành công", "Agency.aspx");
                uploadData();
            }
            else
            {
                MessageBox("Thêm không thành công", "Agency.aspx");
                uploadData();
            }
        }
    }
}