using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DTO;
using System.Data;

namespace Quan_Ly_Ve_So.UI
{
    public partial class Edit_Deal : System.Web.UI.Page
    {
        string id_edit1, id_edit2, id_edit3;
        private DealBL DBL = new DealBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id_edit1 = Request["edit1"];
                id_edit2 = Request["edit2"];
                id_edit3 = Request["edit3"];                

                loadDataFind();
            }

        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }



        public void loadDataFind()
        {
            DealDTO DO = new DealDTO();
            DO.ID_TYPE = id_edit1;
            DO.ID_AGENCY = id_edit2;
            DO.DATE_RECEIVE = id_edit3;

            DataTable tb = DBL.Find_mul_deal(DO);
            input_Type.Text = tb.Rows[0][0].ToString();
            input_Agency.Text = tb.Rows[0][1].ToString();
            input_QuantityReceive.Text = tb.Rows[0][2].ToString();
            input_QuantitySell.Text = tb.Rows[0][3].ToString();

            string[] date = tb.Rows[0][4].ToString().Split(' ');
            input_DateReceive.Text = date[0];
            input_Commission.Text = tb.Rows[0][5].ToString();
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            DealDTO DO = new DealDTO();

            DO.ID_TYPE = input_Type.Text;
            DO.ID_AGENCY = input_Agency.Text;
            DO.QUANTITY_RECEIVE = input_QuantityReceive.Text;
            DO.QUANTITY_SELL = input_QuantitySell.Text;

            string[] d = input_DateReceive.Text.Split('/');

            string date = d[1] + "-" + d[0] + "-" + d[2];
            DO.DATE_RECEIVE = date;
                       
            DO.COMMISSION = input_Commission.Text;

            //MessageBox(input_Type.Text + " " + input_Agency.Text + " " + input_QuantityReceive.Text + " " + input_QuantitySell.Text + " " + date + " " + input_Commission.Text, "Deal.aspx");

            if (DBL.Edit(DO) == true)
            {
                MessageBox("Sửa thành công", "Deal.aspx");
            }
            else
            {
                MessageBox("Sửa không thành công", "Deal.aspx");
            }
        }
    }
}