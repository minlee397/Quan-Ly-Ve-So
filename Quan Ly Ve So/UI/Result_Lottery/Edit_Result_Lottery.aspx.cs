using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DAL;
using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quan_Ly_Ve_So.UI.Result_Lottery
{
    public partial class Edit_Result_Lottery : System.Web.UI.Page
    {
        string id_edit;
        private Result_LotteryBL RBL = new Result_LotteryBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                id_edit = Request["edit"];                
                BindData();
                loadDataFind();
                loadinfo();
            }

        }

        public void loadinfo()
        {
            input_Date_result.Attributes.Add("readonly", "readonly");
        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }
   
        public void BindData()
        {
            input_Id_type.DataSource = RBL.TypeList();
            input_Id_type.DataValueField = "ID_TYPE";
            input_Id_type.DataTextField = "TYPE_LIST";
            input_Id_type.DataBind();
            ConnectDB.con.Close();

            input_Id_prize.DataSource = RBL.PrizeList();
            input_Id_prize.DataValueField = "ID_PRIZE";
            input_Id_prize.DataTextField = "PRIZE_LIST";
            input_Id_prize.DataBind();
            ConnectDB.con.Close();
        }

        public void loadDataFind()
        {
            DataTable tb = RBL.Find("ID_RESULT", id_edit);
            input_Id_result.Text = id_edit;            
            input_Id_type.SelectedValue = tb.Rows[0][1].ToString();
            input_Id_prize.SelectedValue = tb.Rows[0][2].ToString();

            string[] date = tb.Rows[0][3].ToString().Split(' ');

            input_Date_result.Text = date[0];
            input_Number_win.Text = tb.Rows[0][4].ToString();            
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Result_LotteryDTO RSL = new Result_LotteryDTO();

            RSL.ID_RESULT = input_Id_result.Text;
            RSL.ID_TYPE = input_Id_type.SelectedValue;
            RSL.ID_PRIZE = input_Id_prize.SelectedValue;

            string[] d = input_Date_result.Text.Split('/');
            string date = d[1] + "-" + d[0] + "-" + d[2];
            RSL.DATE_RESULT = date;
            RSL.NUMBER_WIN = input_Number_win.Text;
            

            if (RBL.Edit(RSL) == true)
            {
                MessageBox("Sửa thành công", "Result_Lottery.aspx");
            }
            else
            {
                MessageBox("Sửa không thành công", "Result_Lottery.aspx");
            }
        }
    }
}