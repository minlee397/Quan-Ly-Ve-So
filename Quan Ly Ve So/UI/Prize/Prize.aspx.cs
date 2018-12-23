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

namespace Quan_Ly_Ve_So.UI.Prize
{
    public partial class Prize : System.Web.UI.Page
    {
        private PrizeBL PBL = new PrizeBL();
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
            table_prize.Controls.Remove(content);
            SqlDataReader rd = PBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã Giải Thưởng</th><th>Tên Giải Thưởng</th><th>Tiền thưởng</th><th>Sửa</th><th>Xóa</th>");
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
                    table.Append("<td>" + string.Format("{0:0,0}", rd[2]) + " VNĐ</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Prize?edit=" + rd[0] + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>");
                    table.Append("<td><a href='./Delete_Prize?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
                    table.Append("</tr>");
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_prize.Controls.Add(content);
            ConnectDB.con.Close();
        }

        protected void function_insert_Click(object sender, EventArgs e)
        {
            PrizeDTO PRP = new PrizeDTO();

            PRP.NAME_PRIZE = input_Name_prize.Text;
            PRP.REWARD = float.Parse(input_Reward.Text);

            if (PBL.Insert(PRP) == true)
            {
                MessageBox("Thêm thành công", "Prize.aspx");
                uploadData();
            }
            else
            {
                MessageBox("Thêm không thành công", "Prize.aspx");
                uploadData();
            }
        }
    }
}