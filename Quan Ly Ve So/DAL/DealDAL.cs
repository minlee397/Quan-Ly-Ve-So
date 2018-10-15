using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Quan_Ly_Ve_So.DTO;
using System.Data;

namespace Quan_Ly_Ve_So.DAL
{
    public class DealDAL
    {
        public SqlDataReader LoadData()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_DEAL", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }

        public DataSet TypeList()
        {
            ConnectDB.con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT ID_TYPE FROM TYPE_LOTTERY", ConnectDB.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet AgencyList()
        {
            ConnectDB.con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT ID_AGENCY FROM AGENCY", ConnectDB.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable Find(DealDTO TOP)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("find_MUL_DEAL", ConnectDB.con);
            cmd.Connection = ConnectDB.con;
            cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = TOP.ID_TYPE;
            cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = TOP.ID_AGENCY;
            cmd.Parameters.Add("@DATE", SqlDbType.VarChar).Value = TOP.DATE_RECEIVE;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            ConnectDB.con.Close();
            return tb;
        }

        public void Insert(DealDTO TOP)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert_DEAL", ConnectDB.con);
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = TOP.ID_TYPE;
                cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = TOP.ID_AGENCY;
                cmd.Parameters.Add("@QUANTITY_RECEIVE", SqlDbType.Int).Value = TOP.QUANTITY_RECEIVE;
                cmd.Parameters.Add("@QUANTITY_SELL", SqlDbType.Int).Value = TOP.QUANTITY_SELL;
                cmd.Parameters.Add("@DATE_RECEIVE", SqlDbType.VarChar).Value = TOP.DATE_RECEIVE;
                cmd.Parameters.Add("@COMMISSION", SqlDbType.Float).Value = TOP.COMMISSION;
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
        public void Edit(DealDTO TOP)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("edit_DEAL", ConnectDB.con);
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = TOP.ID_TYPE;
                cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = TOP.ID_AGENCY;
                cmd.Parameters.Add("@QUANTITY_RECEIVE", SqlDbType.Int).Value = TOP.QUANTITY_RECEIVE;
                cmd.Parameters.Add("@QUANTITY_SELL", SqlDbType.Int).Value = TOP.QUANTITY_SELL;
                cmd.Parameters.Add("@DATE_RECEIVE", SqlDbType.VarChar).Value = TOP.DATE_RECEIVE;
                cmd.Parameters.Add("@COMMISSION", SqlDbType.Float).Value = TOP.COMMISSION;
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
                SqlCommand cmd = new SqlCommand("delete_DEAL", ConnectDB.con);
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = id_delete;
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