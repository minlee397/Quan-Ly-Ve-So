using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DTO;
using System.Data;
using Quan_Ly_Ve_So.DAL;

namespace Quan_Ly_Ve_So.UI
{
	public partial class Edit_SignUp_Lottery : System.Web.UI.Page
	{
		string id_edit;
		private SignUp_LotteryBL SULBL = new SignUp_LotteryBL();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				id_edit = Request["edit"];
				input_id_sign.Text = id_edit;
                Loadinfo();
				loadDataFind();
                BindData();
            }

		}

		public void MessageBox(string str, string Path)
		{
			Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
		}

        public void Loadinfo()
        {
            input_id_agency.Items.Add(new ListItem("Chọn đại lý", "none"));
            input_Id_type.Items.Add(new ListItem("Chọn loại vé số", "none"));
        }

        public void BindData()
        {
            input_id_agency.DataSource = SULBL.AgencyList();
            input_id_agency.DataValueField = "ID_AGENCY";
            input_id_agency.DataTextField = "AGENCY_LIST";
            input_id_agency.DataBind();
            ConnectDB.con.Close();

            input_Id_type.DataSource = SULBL.TypeList();
            input_Id_type.DataValueField = "ID_TYPE";
            input_Id_type.DataTextField = "TYPE_LIST";
            input_Id_type.DataBind();
            ConnectDB.con.Close();
        }

        public void loadDataFind()
		{
			DataTable tb = SULBL.Find("ID_SIGN", id_edit);
			input_id_sign.Text = id_edit;
			input_id_agency.Text = tb.Rows[0][1].ToString();
            input_Id_type.Text = tb.Rows[0][2].ToString();
            string[] date = tb.Rows[0][3].ToString().Split(' ');
            input_date_sign.Text = date[0];
			input_quantity.Text = tb.Rows[0][4].ToString();
		}

		protected void btn_edit_Click(object sender, EventArgs e)
		{
			SignUp_LotteryDTO SULO = new SignUp_LotteryDTO();

			SULO.ID_SIGN = input_id_sign.Text;
			SULO.ID_AGENCY = input_id_agency.SelectedValue;
            SULO.ID_TYPE = input_Id_type.SelectedValue;
            string[] d = input_date_sign.Text.Split('/');
            string date = d[1] + "-" + d[0] + "-" + d[2];

            SULO.DATE_SIGN = date;
            SULO.QUANITY_SIGN = int.Parse(input_quantity.Text);

			if (SULBL.Edit(SULO) == true)
			{
				MessageBox("Sửa thành công", "SignUp_Lottery.aspx");
			}
			else
			{
				MessageBox("Sửa không thành công", "SignUp_Lottery.aspx");
			}
		}
	}
}