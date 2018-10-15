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
    public partial class Type_Lottery : System.Web.UI.Page
    {
        private Type_LotteryBL TBL = new Type_LotteryBL();
        StringBuilder table;
        Literal content;        
        protected void Page_Load(object sender, EventArgs e)
        {
            uploadData();               
        }

        public void MessageBox(string str, string Path)
        {            
            Response.Write("<script> alert('"+str+ ".'); window.location.href='./"+Path+"'; </script>");
        }
      
        public void uploadData()
        {
            table_lottery.Controls.Remove(content);
            SqlDataReader rd = TBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã Đài</th><th>Tên Đài</th><th>Sửa</th><th>Xóa</th>");
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
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Type_Lottery?edit="+rd[0]+"'><i class='fa fa-edit'></i></a>");                                       
                    table.Append("</td>");
                    table.Append("<td><a href='Delete_Type_Lottery?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
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
            Type_LotteryDTO TLO = new Type_LotteryDTO();
            
            TLO.CHANNEL = input_Channel.Text;                   
            
            if (TBL.Insert(TLO) == true)
            {
                MessageBox("Thêm thành công", "Type_Lottery.aspx");
                uploadData();                
            }
            else
            {
                MessageBox("Thêm không thành công", "Type_Lottery.aspx");
                uploadData();                
            }
        }
    }
}