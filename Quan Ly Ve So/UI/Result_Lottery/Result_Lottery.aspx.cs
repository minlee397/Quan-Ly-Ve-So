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

namespace Quan_Ly_Ve_So.UI.Result_Lottery
{
    public partial class Result_Lottery : System.Web.UI.Page
    {
        private Result_LotteryBL RBL = new Result_LotteryBL();
        StringBuilder table;
        Literal content;
        protected void Page_Load(object sender, EventArgs e)
        {
            uploadData();
            BindData();
            loadinfo();
        }

        public void loadinfo()
        {
            input_Date_result.Attributes.Add("readonly", "readonly");
        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }

        public void BindData()
        {
            input_Id_type.DataSource = RBL.TypeList();
            input_Id_type.DataValueField = "ID_TYPE";
            input_Id_type.DataTextField = "TYPE_LIST";
            input_Id_type.DataBind();
            ConnectDB.con.Close();

            input_Id_prize.DataSource = RBL.PrizeList();
            input_Id_prize.DataValueField = "ID_PRIZE";
            input_Id_prize.DataTextField = "PRIZE_LIST";
            input_Id_prize.DataBind();
            ConnectDB.con.Close();
        }

        public void uploadData()
        {
            table_lottery.Controls.Remove(content);
            SqlDataReader rd = RBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã kết quả</th><th>Mã loại vé số</th><th>Mã loại giải</th><th>Ngày xổ</th><th>Số trúng</th><th>Sửa</th><th>Xóa</th>");
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
                    table.Append("<td>" + rd[3] + "</td>");
                    table.Append("<td>" + rd[4] + "</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Result_Lottery?edit=" + rd[0] + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>");
                    table.Append("<td><a href='./Delete_Result_Lottery?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
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
            Result_LotteryDTO RSL = new Result_LotteryDTO();

            RSL.ID_TYPE = input_Id_type.SelectedValue;
            RSL.ID_PRIZE = input_Id_prize.SelectedValue;

            string[] d = input_Date_result.Text.Split('/');
            string date = d[1] + "-" + d[0] + "-" + d[2];

            RSL.DATE_RESULT = date;         
            RSL.NUMBER_WIN = input_Number_win.Text;           
                        
            if (RBL.Insert(RSL) == true)
            {
                MessageBox("Thêm thành công", "Result_Lottery.aspx");
                uploadData();
            }
            else
            {
                MessageBox("Thêm không thành công", "Result_Lottery.aspx");
                uploadData();
            }
        }        

        
    }
}