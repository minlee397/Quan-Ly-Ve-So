using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quan_Ly_Ve_So.DTO;
using Quan_Ly_Ve_So.BL;
using System.Data.SqlClient;
using System.Text;
using Quan_Ly_Ve_So.DAL;
using System.Data;

namespace Quan_Ly_Ve_So.UI
{
    public partial class Deal : System.Web.UI.Page
    {
        private DealBL DBL = new DealBL();
        StringBuilder table;
        Literal content;
        protected void Page_Load(object sender, EventArgs e)
        {
            uploadData();
            if(!IsPostBack)
            {
                BindData();
                Loadinfo();
            }
        }

        public void Loadinfo()
        {
            DateTime date = DateTime.Now;
            input_DateReceive.Text = date.ToString("dd/MM/yyyy");
            input_DateReceive.Attributes.Add("readonly", "readonly");
            input_QuantityReceive.Attributes.Add("readonly", "readonly");
            input_QuantitySell.Attributes.Add("readonly", "readonly");
            input_Commission.Attributes.Add("readonly", "readonly");

            //Load tìm theo
            Search_by.Items.Add(new ListItem("Tìm theo: ", "NONE"));
            Search_by.Items.Add(new ListItem("Mã đài", "ID_TYPE"));
            Search_by.Items.Add(new ListItem("Mã đại lý", "ID_AGENCY"));

        }

        public void BindData()
        {
            ddlType.Items.Add(new ListItem("Chọn loại vé số", "veso"));
            ddlType.DataSource = DBL.TypeList();         
            ddlType.DataValueField = "ID_TYPE";            
            ddlType.DataTextField = "TYPE_LIST";
            ddlType.DataBind();           
            ConnectDB.con.Close();

            ddlAgency.Items.Add(new ListItem("Chọn đại lý", "daily"));
            ddlAgency.DataSource = DBL.AgencyList();
            ddlAgency.DataValueField = "ID_AGENCY";
            ddlAgency.DataTextField = "AGENCY_LIST";
            ddlAgency.DataBind();
            ConnectDB.con.Close();
        }
        public void MessageBox(string str, string Path)
        {
            Response.Write("<script> alert('" + str + ".'); window.location.href='./" + Path + "'; </script>");
        }
        public void uploadData()
        {
            table_deal.Controls.Remove(content);
            SqlDataReader rd = DBL.LoadData();
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Mã đài</th><th>Mã đại lý</th><th>Số lượng nhận</th><th>Số lượng bán</th><th>Ngày nhận</th><th>Hoa hồng</th><th>Tổng tiền</th><th>Xem</th><th>Sửa</th><th>Xóa</th>");
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
                    table.Append("<td>" + rd[3] + "</td>");

                    string[] d = rd[4].ToString().Split(' ');
                    string[] date_s = d[0].Split('/');
                    string date = date_s[1] + "-" + date_s[0] + "-" + date_s[2];

                    table.Append("<td>" + d[0] + "</td>");
                    table.Append("<td>" + rd[5] + " %</td>");

                    float price = (float.Parse(rd[3].ToString()) * 10000);
                    float commssion = price * (float.Parse(rd[5].ToString()) / 100);
                    float total_price = price - commssion;

                    table.Append("<td>" + string.Format("{0:0,0}",total_price) + " VNĐ</td>");

                    table.Append("<td>");
                    table.Append("<a href='' data-toggle='modal' data-target='#" + rd[0] + "-" + rd[1] + "-" + date + "'><i class='fa fa-eye'></i></a>");

                    // View Row
                    table.Append("<div id='" + rd[0] + "-" + rd[1] + "-" + date + "' class='modal fade' role='dialog'>");

                    table.Append("<div class='modal-dialog'>");
                    table.Append("<div class='modal-content'>");
                    table.Append("<div class='modal-header'>");
                    table.Append("<button type = 'button' class='close' data-dismiss='modal'>&times;</button>");
                    table.Append("<h4 class='modal-title custom'>Xem chi tiết</h4>");
                    table.Append("</div>");
                    table.Append("<div class='modal-body'>");
                    table.Append("<div class='row'>");

                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đài: </span>" + rd[0] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đại lý: </span>" + rd[1] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Số lượng nhận: </span>" + rd[2] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Ngày nhận: </span>" + d[0] + "</div></div>");
                    table.Append("</div>");


                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đài: </span>" + rd[6] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đại lý: </span>" + rd[7] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Số lượng bán: </span>" + rd[3] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Hoa hồng: </span>" + rd[5] + "%</div></div>");
                    table.Append("</div>");



                    table.Append("</div>");
                    table.Append("</div>");
                    table.Append("<div class='modal-footer'>");
                    table.Append("<button type='button' class='btn btn-danger' data-dismiss='modal'>Đóng</button>");
                    table.Append("</div>");
                    table.Append("</div>");
                    table.Append("</div>");

                    table.Append("</div>");

                    table.Append("</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Deal?edit1=" + rd[0] + "&edit2=" + rd[1] + "&edit3=" + date + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>"); 
                    table.Append("<td><a href='./Delete_Deal?delete1=" + rd[0] + "&delete2="+rd[1]+"&delete3="+date+"'><i class='fa fa-trash'></i></a></td>");
                    table.Append("</tr>");
                    i++;
                }
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_deal.Controls.Add(content);
            ConnectDB.con.Close();
        }
        protected void function_insert_Click(object sender, EventArgs e)
        {
            DealDTO DO = new DealDTO();

            DO.ID_TYPE = ddlType.Text;
            DO.ID_AGENCY = ddlAgency.Text;
            DO.QUANTITY_RECEIVE = input_QuantityReceive.Text;
            
            DO.QUANTITY_SELL = input_QuantitySell.Text;

            string[] d = input_DateReceive.Text.Split('/');
            string date = d[1] + "-" + d[0] + "-" + d[2];
            DO.DATE_RECEIVE = date;
            DO.COMMISSION = "10";

            if (input_QuantityReceive.Text != "")
            {
                if (DBL.Insert(DO) == true)
                {
                    MessageBox("Thêm thành công", "Deal.aspx");
                    uploadData();
                }
                else
                {
                    MessageBox("Lỗi hệ thống", "Deal.aspx");
                    uploadData();
                }
            }
            else
            {
                MessageBox("Lỗi dữ liệu vào, xem lại lỗi ở khung dưới thêm!!!", "Deal.aspx");
            }
        }

        protected void button_find_Click(object sender, EventArgs e)
        {
            table_deal.Controls.Remove(content);
            string search_by = Search_by.SelectedValue;
            string value = input_search.Text;

            if (search_by == "NONE")
            {
                MessageBox("Hãy Chọn tìm theo", "Deal.aspx");
            }
            else
            {
                DataTable rd = DBL.Find(search_by, value);
                table = new StringBuilder();
                table.Append("<table class='table table-hover'");
                table.Append("<tr>");
                table.Append("<th>STT</th><th>Mã đài</th><th>Mã đại lý</th><th>Số lượng nhận</th><th>Số lượng bán</th><th>Ngày nhận</th><th>Hoa hồng</th><th>Xem</th><th>Sửa</th><th>Xóa</th>");
                table.Append("</tr>");


                for (int i = 0; i < rd.Rows.Count; i++)
                {
                    table.Append("<tr>");
                    table.Append("<td>" + (i + 1) + "</td>");
                    table.Append("<td>" + rd.Rows[i][0] + "</td>");
                    table.Append("<td>" + rd.Rows[i][1] + "</td>");
                    table.Append("<td>" + rd.Rows[i][2] + "</td>");
                    table.Append("<td>" + rd.Rows[i][3] + "</td>");

                    string[] d = rd.Rows[i][4].ToString().Split(' ');
                    string[] date_s = d[0].Split('/');
                    string date = date_s[1] + "-" + date_s[0] + "-" + date_s[2];

                    table.Append("<td>" + d[0] + "</td>");
                    table.Append("<td>" + rd.Rows[i][5] + " %</td>");
                    table.Append("<td>");
                    table.Append("<a href='' data-toggle='modal' data-target='#" + rd.Rows[i][0] + "-" + rd.Rows[i][1] + "-" + date + "'><i class='fa fa-eye'></i></a>");

                    // View Row
                    table.Append("<div id='" + rd.Rows[i][0] + "-" + rd.Rows[i][1] + "-" + date + "' class='modal fade' role='dialog'>");

                    table.Append("<div class='modal-dialog'>");
                    table.Append("<div class='modal-content'>");
                    table.Append("<div class='modal-header'>");
                    table.Append("<button type = 'button' class='close' data-dismiss='modal'>&times;</button>");
                    table.Append("<h4 class='modal-title custom'>Xem chi tiết</h4>");
                    table.Append("</div>");
                    table.Append("<div class='modal-body'>");
                    table.Append("<div class='row'>");

                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đài: </span>" + rd.Rows[i][0] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Mã đại lý: </span>" + rd.Rows[i][1] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Số lượng nhận: </span>" + rd.Rows[i][2] + "</div></div>");
                    table.Append("<div class='row info_deal_left'><div class='col-sm-12'><span>Ngày nhận: </span>" + d[0] + "</div></div>");
                    table.Append("</div>");


                    table.Append("<div class='col-sm-6'>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đài: </span>" + rd.Rows[i][6] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Tên đại lý: </span>" + rd.Rows[i][7] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Số lượng bán: </span>" + rd.Rows[i][3] + "</div></div>");
                    table.Append("<div class='row info_deal_right'><div class='col-sm-12'><span>Hoa hồng: </span>" + rd.Rows[i][5] + "%</div></div>");
                    table.Append("</div>");



                    table.Append("</div>");
                    table.Append("</div>");
                    table.Append("<div class='modal-footer'>");
                    table.Append("<button type='button' class='btn btn-danger' data-dismiss='modal'>Đóng</button>");
                    table.Append("</div>");
                    table.Append("</div>");
                    table.Append("</div>");

                    table.Append("</div>");

                    table.Append("</td>");
                    table.Append("<td>");
                    table.Append("<a href='./Edit_Deal?edit1=" + rd.Rows[i][0] + "&edit2=" + rd.Rows[i][1] + "&edit3=" + date + "'><i class='fa fa-edit'></i></a>");
                    table.Append("</td>");
                    table.Append("<td><a href='./Delete_Deal?delete1=" + rd.Rows[i][0] + "&delete2=" + rd.Rows[i][1] + "&delete3=" + date + "'><i class='fa fa-trash'></i></a></td>");
                    table.Append("</tr>");

                }

                table.Append("</table>");
                content = new Literal { Text = table.ToString() };
                table_deal.Controls.Add(content);
                ConnectDB.con.Close();
            }
        }

        public void printf_table_batch(DataTable rd)
        {
            table_batch.Controls.Remove(content);
            table = new StringBuilder();
            table.Append("<table class='table table-hover'");
            table.Append("<tr>");
            table.Append("<th>STT</th><th>Số lượng nhận</th><th>Số lượng bán</th><th>Ngày nhận</th><th>Tỉ lệ bán được</th>");
            table.Append("</tr>");

            for (int i = 0; i < rd.Rows.Count; i++)
            {
                table.Append("<tr>");
                table.Append("<td>" + (i + 1) + "</td>");
                table.Append("<td>" + rd.Rows[i][3] + "</td>");
                table.Append("<td>" + rd.Rows[i][4] + "</td>");

                string[] d = rd.Rows[i][5].ToString().Split(' ');
                string[] date_s = d[0].Split('/');
                string date = date_s[1] + "-" + date_s[0] + "-" + date_s[2];

                table.Append("<td>" + date + "</td>");
                table.Append("<td>" + (float.Parse(rd.Rows[i][4].ToString()) / float.Parse(rd.Rows[i][3].ToString())) + "</td>");
                table.Append("</tr>");
            }
            table.Append("</table>");
            content = new Literal { Text = table.ToString() };
            table_batch.Controls.Add(content);
        }

        public void cal_batch()
        {
            string Id_agency = ddlAgency.SelectedValue;
            string Id_type = ddlType.SelectedValue;
            DataTable rd = DBL.Get_Quantity_sign(Id_agency, Id_type);

            if ((int)rd.Rows[0][0] == -1)
            {
                cal_QuantityReceive.Style.Add("display", "none");
                error_sentence.Style.Add("display", "block");
                error_input_QuantityReceive.Text = "Đại lý này chưa đăng kí loại vé số này, Hãy đăng kí vé số trước khi thêm đợt!!!";
                input_QuantityReceive.Text = "";
                function_insert.Enabled = false;
            }
            else if ((int)rd.Rows[0][0] == 0)
            {
                function_insert.Enabled = true;
                cal_QuantityReceive.Style.Add("display", "none");
                error_sentence.Style.Add("display", "none");
                input_QuantityReceive.Text = rd.Rows[0][1].ToString();
                error_input_QuantityReceive.Text = "";
            }
            else if ((int)rd.Rows[0][0] == 1)
            {
                function_insert.Enabled = true;
                error_sentence.Style.Add("display", "none");
                error_input_QuantityReceive.Text = "";
                cal_QuantityReceive.Style.Add("display", "block");
                title_batch.Text = "Tổng 3 đợt trước của đại lý: " + rd.Rows[0][2] + ", đăng ký loại vé số: " + rd.Rows[0][1];

                float q = (float.Parse(rd.Rows[0][4].ToString()) / float.Parse(rd.Rows[0][3].ToString())) * 100;
                int Quantity = (int)q;

                printf_table_batch(rd);
                cal_quantity.Text = "Do 1 đợt => (" + Quantity + ")/1 = " + q;

                string QuantityReceive = Quantity.ToString();
                input_QuantityReceive.Text = QuantityReceive;
            }
            else if ((int)rd.Rows[0][0] == 2)
            {
                function_insert.Enabled = true;
                error_sentence.Style.Add("display", "none");
                error_input_QuantityReceive.Text = "";
                cal_QuantityReceive.Style.Add("display", "block");
                title_batch.Text = "Tổng 3 đợt trước của đại lý: " + rd.Rows[0][2] + ", đăng ký loại vé số: " + rd.Rows[0][1];

                float Quantity_1 = (float.Parse(rd.Rows[0][4].ToString()) / float.Parse(rd.Rows[0][3].ToString()));
                float Quantity_2 = (float.Parse(rd.Rows[1][4].ToString()) / float.Parse(rd.Rows[1][3].ToString()));

                float q = ((Quantity_1 + Quantity_2) / 2) * 100;
                int Quantity = (int)q;

                printf_table_batch(rd);
                cal_quantity.Text = "Do 2 đợt => (" + Quantity_1 + " + " + Quantity_2 + ")/2 = " + q;

                string QuantityReceive = Quantity.ToString();
                input_QuantityReceive.Text = QuantityReceive;
            }
            else if ((int)rd.Rows[0][0] == 3)
            {
                function_insert.Enabled = true;
                error_sentence.Style.Add("display", "none");
                error_input_QuantityReceive.Text = "";
                cal_QuantityReceive.Style.Add("display", "block");
                title_batch.Text = "Tổng 3 đợt trước của đại lý: " + rd.Rows[0][2] + ", đăng ký loại vé số: " + rd.Rows[0][1];

                float Quantity_1 = (float.Parse(rd.Rows[0][4].ToString()) / float.Parse(rd.Rows[0][3].ToString()));
                float Quantity_2 = (float.Parse(rd.Rows[1][4].ToString()) / float.Parse(rd.Rows[1][3].ToString()));
                float Quantity_3 = (float.Parse(rd.Rows[2][4].ToString()) / float.Parse(rd.Rows[2][3].ToString()));

                float q = ((Quantity_1 + Quantity_2 + Quantity_3) / 3) * 100;
                int Quantity = (int)q;

                printf_table_batch(rd);
                cal_quantity.Text = "Do 3 đợt => (" + Quantity_1 + " + " + Quantity_2 + " + " + Quantity_2 + ")/3 = " + q;

                string QuantityReceive = Quantity.ToString();
                input_QuantityReceive.Text = QuantityReceive;
            }
        }

        protected void ddlAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            cal_batch();
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cal_batch();
        }
    }
}