using Quan_Ly_Ve_So.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI.Prize
{
    public partial class Delete_Prize : System.Web.UI.Page
    {
        private string id_delete;
        private PrizeBL TBL = new PrizeBL();
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
            if (TBL.Delete(id_delete) == true)
            {
                MessageBox("Xóa thành công", "Prize.aspx");
            }
            else
            {
                MessageBox("Xóa không thành công", "Prize.aspx");
            }
        }
    }
}