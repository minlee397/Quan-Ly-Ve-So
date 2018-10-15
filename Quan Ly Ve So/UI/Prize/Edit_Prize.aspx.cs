using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI.Prize
{
    public partial class Edit_Prize : System.Web.UI.Page
    {
        string id_edit;
        private PrizeBL TBL = new PrizeBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id_edit = Request["edit"];
                input_Id_prize.Text = id_edit;

                loadDataFind();
            }

        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }



        public void loadDataFind()
        {
            DataTable tb = TBL.Find("ID_PRIZE", id_edit);
            input_Id_prize.Text = id_edit;
            input_Name_prize.Text = tb.Rows[0][1].ToString();
            input_Reward.Text = tb.Rows[0][2].ToString();
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            PrizeDTO TLO = new PrizeDTO();


            TLO.NAME_PRIZE = input_Name_prize.Text;
            TLO.REWARD = float.Parse(input_Reward.Text);
            TLO.ID_PRIZE = input_Id_prize.Text;

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