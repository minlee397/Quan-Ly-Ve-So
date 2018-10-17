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
using System.Data;

namespace Quan_Ly_Ve_So.UI
{
    public partial class Type_Lottery : System.Web.UI.Page
    {
        private Type_LotteryBL TBL = new Type_LotteryBL();
        StringBuilder table;
        Literal content;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uploadData();
                uploadInfo();
            }
         
        }

        public void MessageBox(string str, string Path)
        {            
            Response.Write("<script> alert('"+str+ ".'); window.location.href='./"+Path+"'; </script>");
        }
        
        public void uploadInfo()
        {
            //Tìm kiếm theo
            Search_by.Items.Add(new ListItem("Tìm Theo", "NONE"));
            Search_by.Items.Add(new ListItem("Mã Đài", "ID_TYPE"));
            Search_by.Items.Add(new ListItem("Tên Đài", "NAME_TYPE"));
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

        protected void button_find_Click(object sender, EventArgs e)
        {
            table_lottery.Controls.Remove(content);
            string search_by = Search_by.SelectedValue;
            string value = input_search.Text;
            
            if (search_by == "NONE")
            {
                MessageBox("Bạn phải chọn tìm theo:", "Type_Lottery.aspx");
            }
            else
            {
                DataTable rd = TBL.Find(search_by, value);
                table = new StringBuilder();
                table.Append("<table class='table table-hover'");
                table.Append("<tr>");
                table.Append("<th>STT</th><th>Mã Đài</th><th>Tên Đài</th><th>Sửa</th><th>Xóa</th>");
                table.Append("</tr>");


                for (int i = 0; i < rd.Rows.Count; i++)
                {
                    table.Append("<tr>");
                    table.Append("<td>" + (i + 1) + "</td>");
                    table.Append("<td>" + rd.Rows[i][0] + "</td>");
                    table.Append("<td>" + rd.Rows[i][1] + "</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Type_Lottery?edit=" + rd.Rows[i][0] + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>");
                    table.Append("<td><a href='Delete_Type_Lottery?delete=" + rd.Rows[i][0] + "'><i class='fa fa-trash'></i></a></td>");
                    table.Append("</tr>");                    
                }
                table.Append("</table>");
                content = new Literal { Text = table.ToString() };
                table_lottery.Controls.Add(content);
                ConnectDB.con.Close();
            }
        }
    }
}