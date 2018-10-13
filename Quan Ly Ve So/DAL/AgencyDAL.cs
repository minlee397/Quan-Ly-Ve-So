using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DAL
{
    public class AgencyDAL
    {

        public SqlDataReader LoadData()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_AGENCY", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }

        public DataTable Find(string search_by, string value)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("find_AGENCY", ConnectDB.con);
            cmd.Connection = ConnectDB.con;
            cmd.Parameters.Add("@SEARCH_BY", SqlDbType.NVarChar).Value = search_by;
            cmd.Parameters.Add("@VALUE", SqlDbType.NVarChar).Value = value;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            ConnectDB.con.Close();
            return tb;
        }

        public void Insert(AgencyDTO TOP)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert_Agency", ConnectDB.con);
                cmd.Parameters.Add("@NAME_AGENCY", SqlDbType.NVarChar).Value = TOP.NAME_AGENCY;
                cmd.Parameters.Add("@ADDR", SqlDbType.NVarChar).Value = TOP.ADDR;
                cmd.Parameters.Add("@NUMPHONE", SqlDbType.VarChar).Value = TOP.NUMPHONE;
                cmd.Parameters.Add("@ACTIVATE", SqlDbType.Int).Value = TOP.ACTIVATE;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                ConnectDB.con.Close();
            }
        }
        public void Edit(AgencyDTO TOP)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("edit_Agency", ConnectDB.con);
                cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = TOP.ID_AGENCY;
                cmd.Parameters.Add("@NAME_AGENCY", SqlDbType.NVarChar).Value = TOP.NAME_AGENCY;
                cmd.Parameters.Add("@ADDR", SqlDbType.NVarChar).Value = TOP.ADDR;
                cmd.Parameters.Add("@NUMPHONE", SqlDbType.VarChar).Value = TOP.NUMPHONE;
                cmd.Parameters.Add("@ACTIVATE", SqlDbType.Int).Value = TOP.ACTIVATE;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                ConnectDB.con.Close();
            }
        }
        public void Delete(string id_delete)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("delete_Agency", ConnectDB.con);
                cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = id_delete;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                ConnectDB.con.Close();
            }
        }
    }
}