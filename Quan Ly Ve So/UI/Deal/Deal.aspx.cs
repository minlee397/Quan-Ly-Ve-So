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
    public partial class Deal : System.Web.UI.Page
    {
        private DealBL DBL = new DealBL();
        StringBuilder table;
        Literal content;
        protected void Page_Load(object sender, EventArgs e)
        {
            uploadData();
            if(!IsPostBack)
            {
                BindData();
                Loadinfo();
            }
        }

        public void Loadinfo()
        {
            DateTime date = DateTime.Now;
            input_DateReceive.Text = date.ToString("dd/MM/yyyy");
            input_DateReceive.Attributes.Add("readonly", "readonly");
            input_QuantitySell.Attributes.Add("readonly", "readonly");
        }

        public void BindData()
        {
            ddlType.DataSource = DBL.TypeList();         
            ddlType.DataValueField = "ID_TYPE";            
            ddlType.DataBind();           
            ConnectDB.con.Close();

            ddlAgency.DataSource = DBL.AgencyList();
            ddlAgency.DataValueField = "ID_AGENCY";
            ddlAgency.DataBind();
            ConnectDB.con.Close();
        }
        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }
        public void uploadData()
        {
            table_deal.Controls.Remove(content);
            SqlDataReader rd = DBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã đài</th><th>Mã đại lý</th><th>Số lượng nhận</th><th>Số lượng bán</th><th>Ngày nhận</th><th>Hoa hồng</th><th>Sửa</th><th>Xóa</th>");
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

                    string[] d = rd[4].ToString().Split(' ');
                    string[] date_s = d[0].Split('/');
                    string date = date_s[1] + "-" + date_s[0] + "-" + date_s[2];

                    table.Append("<td>" + d[0] + "</td>");
                    table.Append("<td>" + rd[5] + "</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Deal?edit1=" + rd[0] + "&edit2=" + rd[1] + "&edit3=" + date + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>"); 
                    table.Append("<td><a href='./Delete_Deal?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
                    table.Append("</tr>");
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_deal.Controls.Add(content);
            ConnectDB.con.Close();
        }
        protected void function_insert_Click(object sender, EventArgs e)
        {
            DealDTO DO = new DealDTO();

            DO.ID_TYPE = ddlType.Text;
            DO.ID_AGENCY = ddlAgency.Text;
            DO.QUANTITY_RECEIVE = input_QuantityReceive.Text;
            
            DO.QUANTITY_SELL = input_QuantitySell.Text;

            string[] d = input_DateReceive.Text.Split('/');
            string date = d[1] + "-" + d[0] + "-" + d[2];
            DO.DATE_RECEIVE = date;
            DO.COMMISSION = input_Commission.Text;

            

            if (DBL.Insert(DO) == true)
            {
                MessageBox("Thêm thành công", "Deal.aspx");
                uploadData();
            }
            else
            {
                MessageBox("Thêm không thành công", "Deal.aspx");
                uploadData();
            }
        }
    }
}