using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DTO;

namespace Quan_Ly_Ve_So.UI
{
    public partial class Delete_Deal : System.Web.UI.Page
    {
        private string id_delete1, id_delete2, id_delete3;
        private DealBL DBL = new DealBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            id_delete1 = Request["delete1"];
            id_delete2 = Request["delete2"];
            id_delete3 = Request["delete3"];
        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            DealDTO TOP = new DealDTO();
            TOP.ID_TYPE = id_delete1;
            TOP.ID_AGENCY = id_delete2;
            TOP.DATE_RECEIVE = id_delete3;
            if (DBL.Delete(TOP) == true)
            {
                MessageBox("Xóa thành công", "Deal.aspx");
            }
            else
            {
                MessageBox("Xóa không thành công", "Deal.aspx");
            }
        }
    }
}