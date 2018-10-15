using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quan_Ly_Ve_So.DTO;
using Quan_Ly_Ve_So.BL;
using System.Data.SqlClient;
using System.Text;
using Quan_Ly_Ve_So.DAL;

namespace Quan_Ly_Ve_So.UI
{
	public partial class SignUp_Lottery : System.Web.UI.Page
	{
        private SignUp_LotteryBL SULBL = new SignUp_LotteryBL();
        StringBuilder table;
        Literal content;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uploadData();
                BindData();
            }
        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }

        public void BindData()
        {
            input_Id_agency.DataSource = SULBL.AgencyList();
            input_Id_agency.DataValueField = "ID_AGENCY";
            input_Id_agency.DataTextField = "AGENCY_LIST";
            input_Id_agency.DataBind();
            ConnectDB.con.Close();
        }

        public void uploadData()
        {
            table_lottery.Controls.Remove(content);
            SqlDataReader rd = SULBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã đăng kí</th><th>Tên đại lý</th><th>Ngày đăng kí</th><th>Số lượng</th><th>Sửa</th><th>Xóa</th>");
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

                    string[] d_split = rd[2].ToString().Split(' ');
                    string[] date = d_split[0].Split('/');

                    table.Append("<td>" + date[0] + "</td>");
                    table.Append("<td>" + rd[3] + "</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_SignUp_Lottery?edit=" + rd[0] + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>");
                    table.Append("<td><a href='Delete_SignUp_Lottery?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
                    table.Append("</tr>");
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_lottery.Controls.Add(content);
            ConnectDB.con.Close();
        }

        protected void function_insert_Click(object sender, EventArgs e)
        {
            SignUp_LotteryDTO SLO = new SignUp_LotteryDTO();

            SLO.ID_AGENCY = input_Id_agency.SelectedValue;

            string[] d = input_Date_sign.Text.Split('/');
            string date = d[1] + "-" + d[0] + "-" + d[2];

            SLO.DATE_SIGN = date;
            SLO.QUANITY_SIGN = int.Parse(input_Quanity_sign.Text);

            if (SULBL.Insert(SLO) == true)
            {
                MessageBox("Thêm thành công", "SignUp_Lottery.aspx");
                uploadData();
            }
            else
            {
                MessageBox("Thêm không thành công", "SignUp_Lottery.aspx");
                uploadData();
            }
        }
    }
}