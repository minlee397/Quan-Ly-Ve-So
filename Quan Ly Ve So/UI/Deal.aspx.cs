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
                Bind();
            }
        }
        public void Bind()
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

            int i = 0;
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
                    table.Append("<td>" + rd[5] + "</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Deal?edit=" + rd[0] + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>");
                    table.Append("<td><a href='Delete_Deal?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
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
            DO.DATE_RECEIVE = input_DateReceive.Text;
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