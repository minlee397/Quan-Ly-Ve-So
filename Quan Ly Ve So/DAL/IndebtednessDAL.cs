using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DAL
{
    public class IndebtednessDAL
    {
        //FUNCTION LOADDATA
        public SqlDataReader LoadData()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_INDEBTEDNESS", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }

        //FUNCTION FIND
        public DataTable Find(string search_by, string value)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("find_INDEBTEDNESS", ConnectDB.con);
            cmd.Parameters.Add("@SEARCH_BY", SqlDbType.VarChar).Value = search_by;
            cmd.Parameters.Add("@VALUE", SqlDbType.VarChar).Value = value;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            ConnectDB.con.Close();
            return tb;
        }
    }
}