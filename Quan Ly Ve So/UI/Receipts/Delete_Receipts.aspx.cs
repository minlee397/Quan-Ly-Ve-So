using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI.Receipts
{
    public partial class Delete_Receipts : System.Web.UI.Page
    {
        private string id_delete;
        private ReceiptsBL RBL = new ReceiptsBL();
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
            ReceiptsDTO RTO = new ReceiptsDTO();
            RTO.ID_TYPE = id_delete;
           
            if (RBL.Delete(RTO) == true)
            {
                MessageBox("Xóa thành công", "Receipts.aspx");
            }
            else
            {
                MessageBox("Xóa không thành công", "Receipts.aspx");
            }
        }
    }
}