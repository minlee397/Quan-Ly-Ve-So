using Quan_Ly_Ve_So.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI
{
    public partial class Delete_Type_Lottery : System.Web.UI.Page
    {
        private string id_delete;
        private Type_LotteryBL TBL = new Type_LotteryBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            id_delete = Request["delete"];
        }

        public void MessageBox(string str, string Path)
        {
            int a = 0;
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (TBL.Delete(id_delete) == true)
            {
                MessageBox("Xóa thành công", "Type_Lottery.aspx");                
            }
            else
            {
                MessageBox("Xóa không thành công", "Type_Lottery.aspx");               
            }
        }
    }
}