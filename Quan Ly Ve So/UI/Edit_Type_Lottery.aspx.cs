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
    public partial class Edit_Type_Lottery : System.Web.UI.Page
    {
        string id_edit;
        private Type_LotteryBL TBL = new Type_LotteryBL();
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
            DataTable tb = TBL.Find("ID_TYPE",id_edit);
            input_id.Text = id_edit;
            input_channel.Text = tb.Rows[0][1].ToString();              
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Type_LotteryDTO TLO = new Type_LotteryDTO();

            
            TLO.CHANNEL = input_channel.Text;
            TLO.ID_TYPE = input_id.Text;

            if (TBL.Edit(TLO) == true)
            {
                MessageBox("Sửa thành công", "Type_Lottery.aspx");                
            }
            else
            {
                MessageBox("Sửa không thành công", "Type_Lottery.aspx");               
            }
        }
    }
}