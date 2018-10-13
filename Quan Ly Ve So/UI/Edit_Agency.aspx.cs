using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI
{
    public partial class Edit_Agency : System.Web.UI.Page
    {
        string id_edit;
        private AgencyBL ABL = new AgencyBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id_edit = Request["edit"];
                input_id.Text = id_edit;

                loadDataFind();
            }

        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }



        public void loadDataFind()
        {
            DataTable tb = ABL.Find("ID_AGENCY", id_edit);
            input_id.Text = id_edit;
            input_name.Text = tb.Rows[0][1].ToString();
            input_addr.Text = tb.Rows[0][2].ToString();
            input_numphone.Text = tb.Rows[0][3].ToString();
            rdo_Activate.SelectedValue = tb.Rows[0][4].ToString();
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            AgencyDTO ALO = new AgencyDTO();


            ALO.NAME_AGENCY = input_name.Text;
            ALO.ADDR = input_addr.Text;
            ALO.NUMPHONE = input_numphone.Text;
            ALO.ACTIVATE = Int32.Parse(rdo_Activate.SelectedValue.ToString());
            ALO.ID_AGENCY = input_id.Text;

            if (ABL.Edit(ALO) == true)
            {
                MessageBox("Sửa thành công", "Agency.aspx");
            }
            else
            {
                MessageBox("Sửa không thành công", "Agency.aspx");
            }
        }
    }
}