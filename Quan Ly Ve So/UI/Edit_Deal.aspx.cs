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
        string id_edit;
        private DealBL DBL = new DealBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id_edit = Request["edit"];
                input_Type.Text = id_edit;

                loadDataFind();
            }

        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }



        public void loadDataFind()
        {
            DataTable tb = DBL.Find("ID_TYPE", id_edit);
            input_Type.Text = id_edit;
            input_Agency.Text = tb.Rows[0][1].ToString();
            input_QuantityReceive.Text = tb.Rows[0][2].ToString();
            input_QuantitySell.Text = tb.Rows[0][3].ToString();
            input_DateReceive.Text = tb.Rows[0][4].ToString();
            input_Commission.Text = tb.Rows[0][5].ToString();
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            DealDTO DO = new DealDTO();

            DO.ID_TYPE = input_Type.Text;
            DO.ID_AGENCY = input_Agency.Text;
            DO.QUANTITY_RECEIVE = input_QuantityReceive.Text;
            DO.QUANTITY_SELL = input_QuantitySell.Text;
            DO.DATE_RECEIVE = input_DateReceive.Text;
            DO.COMMISSION = input_Commission.Text;

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