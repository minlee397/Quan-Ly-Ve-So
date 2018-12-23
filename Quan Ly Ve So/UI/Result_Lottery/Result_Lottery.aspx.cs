using Quan_Ly_Ve_So.BL;
using Quan_Ly_Ve_So.DAL;
using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web;

namespace Quan_Ly_Ve_So.UI.Result_Lottery
{
    public partial class Result_Lottery : System.Web.UI.Page
    {
        private Result_LotteryBL RBL = new Result_LotteryBL();
        StringBuilder table;
        Literal content;       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uploadData();
                BindData();
                loadinfo();
            }           
        }

        public void loadinfo()
        {
            input_Date_result.Attributes.Add("readonly", "readonly");
            input_date_search.Text = DateTime.Now.ToString("dd/MM/yyyy");
            input_date_search.Attributes.Add("readonly", "readonly");            
        }

        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }
        public void MessageBox_not_refresh(string message)
        {
            StringBuilder strScript = new StringBuilder();
            strScript.Append("alert('"+ message + "');");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", strScript.ToString(), true);
        }

        public void BindData()
        {
            input_Id_type.DataSource = RBL.TypeList();
            input_Id_type.DataValueField = "ID_TYPE";
            input_Id_type.DataTextField = "TYPE_LIST";
            input_Id_type.DataBind();
            ConnectDB.con.Close();

            input_id_type_search.DataSource = RBL.TypeList();
            input_id_type_search.DataValueField = "ID_TYPE";
            input_id_type_search.DataTextField = "TYPE_LIST";
            input_id_type_search.DataBind();
            ConnectDB.con.Close();

            input_Id_prize.DataSource = RBL.PrizeList();
            input_Id_prize.DataValueField = "ID_PRIZE";
            input_Id_prize.DataTextField = "PRIZE_LIST";
            input_Id_prize.DataBind();
            ConnectDB.con.Close();
        }

        public void uploadData()
        {
            table_lottery.Controls.Remove(content);
            SqlDataReader rd = RBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã kết quả</th><th>Mã Đài</th><th>Mã loại giải</th><th>Ngày xổ</th><th>Số trúng</th><th>Sửa</th><th>Xóa</th>");
            table.Append("</tr>");

            int i = 1;
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    table.Append("<tr>");
                    table.Append("<td>" + i + "</td>");
                    table.Append("<td>" + rd[0] + "</td>");
                    table.Append("<td>" + rd[1] + "</td>");
                    table.Append("<td>" + rd[2] + "</td>");
                    string[] date = rd[3].ToString().Split(' ');
                    table.Append("<td>" + date[0] + "</td>");
                    table.Append("<td>" + rd[4] + "</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Result_Lottery?edit=" + rd[0] + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>");
                    table.Append("<td><a href='./Delete_Result_Lottery?delete=" + rd[0] + "'><i class='fa fa-trash'></i></a></td>");
                    table.Append("</tr>");
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_lottery.Controls.Add(content);
            ConnectDB.con.Close();
        }

        protected void function_insert_Click(object sender, EventArgs e)
        {
            Result_LotteryDTO RSL = new Result_LotteryDTO();
            RSL.ID_TYPE = input_Id_type.SelectedValue;
            RSL.ID_PRIZE = input_Id_prize.SelectedValue;

            string[] d = input_Date_result.Text.Split('/');
            string date = d[1] + "-" + d[0] + "-" + d[2];

            RSL.DATE_RESULT = date;
            RSL.NUMBER_WIN = input_Number_win.Text;

            if (RBL.Insert(RSL) == true)
            {
                MessageBox("Thêm thành công", "Result_Lottery.aspx");
                uploadData();
            }
            else
            {
                MessageBox("Thêm không thành công", "Result_Lottery.aspx");
                uploadData();
            }
        }
               
        protected void btn_import_data_Click(object sender, EventArgs e)
        {
            FileUpload1.SaveAs(Server.MapPath("~/file_log/" + FileUpload1.FileName));
            if (FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.FileName);
                if(fileExtension.ToLower() == ".txt")
                {
                    string fileDir = Server.MapPath("~/file_log/" + FileUpload1.FileName);                                    
                    using (StreamReader sr = new StreamReader(fileDir))
                    {
                        Result_LotteryDTO RSL = new Result_LotteryDTO();                        
                        string[] line1 = sr.ReadLine().Split('\t');
                        RSL.ID_TYPE = line1[0].Trim();
                        RSL.DATE_RESULT = line1[1].Trim();
                        while (sr.Peek() >= 0)
                        {                            
                            string[] result_line = sr.ReadLine().Split('\t');
                            RSL.ID_PRIZE = result_line[0].Trim();
                            RSL.NUMBER_WIN = result_line[1].Trim();
                            RBL.Insert(RSL);
                        }
                    }                    
                    ConnectDB.con.Close();
                    MessageBox("Đã import dữ liệu thành công", "Result_Lottery.aspx");
                }
                else
                    MessageBox("File phải là dạng txt", "Result_Lottery.aspx");

            }
            else
                MessageBox("Hãy chọn dữ liệu để upload", "Result_Lottery.aspx");            
        }

        private string cutString(string strCut, int lenstring)
        {
            strCut = strCut.Substring(strCut.Length - lenstring, lenstring);
            return strCut;
        }

        /* Chức năng dò số */
        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (input_winner_number_search.Text.Length < 6)
            {
                error_search.Text = "Lỗi: Vé số phải là 6 kí tự , Xin hãy nhập lại !!!";
            }
            else
            {
                error_search.Text = "";
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("CHANNEL", typeof(String));
                dt.Columns.Add(dc);
                dc = new DataColumn("DATE_RESULT", typeof(String));
                dt.Columns.Add(dc);
                dc = new DataColumn("NUMBER_WIN", typeof(String));
                dt.Columns.Add(dc);
                dc = new DataColumn("NAME_PRIZE", typeof(String));
                dt.Columns.Add(dc);
                dc = new DataColumn("REWARD", typeof(String));
                dt.Columns.Add(dc);

                Result_LotteryDTO RSL = new Result_LotteryDTO();
                string[] date = input_date_search.Text.Split('/');
                RSL.DATE_RESULT = date[1] + "/" + date[0] + "/" + date[2];
                RSL.ID_TYPE = input_id_type_search.Text;

                for (int i = 2; i <= 6; i++)
                {
                    RSL.NUMBER_WIN = cutString(input_winner_number_search.Text, i);
                    RSL.LEN_NUMBER = RSL.NUMBER_WIN.Length;
                    SqlDataReader rd = RBL.SearchNumberWin(RSL);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = rd[0];
                            dr[1] = rd[1];
                            dr[2] = rd[2];
                            dr[3] = rd[3];
                            dr[4] = rd[4];
                            dt.Rows.Add(dr);
                        }
                    }
                    ConnectDB.con.Close();
                }
                table = new StringBuilder();
                table.Append("<div class='row'><div class='col-sm-12' style='padding-top:1%;'>Mã vé số - <strong>" + input_winner_number_search.Text + "</strong> , ngày xổ - <strong>" + input_date_search.Text + "</strong></div></div>");
                if(dt.Rows.Count ==0)                
                    table.Append("<div class='row' style='color:#cc5151; padding-top:1%; font-size:20px; font-weight:bold;'><div class='col-sm-12'>Vé số này đã không trúng, chúc quý khách may mắn lần sau</div></div>");                
                else
                    table.Append("<div class='row' style='color:#cc5151; padding-top:1%; font-size:20px; font-weight:bold;'><div class='col-sm-12'>Chúng mình quý khách đã trúng vé số với giải như sau: </div></div>");
                table.Append("<div class='row' style='border-bottom:1px solid #808080; padding-top:1%;'>");
                table.Append("<div class='col-sm-12'>");
                table.Append("<table class='table table-hover'>");
                table.Append("<tr>");
                table.Append("<th>STT</th><th>Số trúng</th><th>Giải</th><th>Trị giá</th>");
                table.Append("</tr>");
                table.Append("</div>");
                table.Append("</div>");

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    table.Append("<tr>");
                    table.Append("<td>" + (j + 1) + "</td>");
                    table.Append("<td>" + dt.Rows[j][2] + "</td>");
                    table.Append("<td>" + dt.Rows[j][3] + "</td>");
                    table.Append("<td>" + string.Format("{0:0,0}", int.Parse(dt.Rows[j][4].ToString())) + " VNĐ</td>");
                    table.Append("</tr>");
                }
                table.Append("</table>");
                content = new Literal { Text = table.ToString() };
                table_result_number.Controls.Add(content);
            }        
        }
    }
}