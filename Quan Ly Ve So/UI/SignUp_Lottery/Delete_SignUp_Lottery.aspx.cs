using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quan_Ly_Ve_So.BL;

namespace Quan_Ly_Ve_So.UI
{
	public partial class Delete_SignUp_Lottery : System.Web.UI.Page
	{
		private string id_delete;
		private SignUp_LotteryBL SULBL = new SignUp_LotteryBL();
		protected void Page_Load(object sender, EventArgs e)
		{
			id_delete = Request["delete"];
		}

		public void MessageBox(string str, string Path)
		{
			Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
		}

		protected void btn_delete_Click(object sender, EventArgs e)
		{
			if (SULBL.Delete(id_delete) == true)
			{
				MessageBox("Xóa thành công", "SignUp_Lottery.aspx");
			}
			else
			{
				MessageBox("Xóa không thành công", "SignUp_Lottery.aspx");
			}
		}
	}
}