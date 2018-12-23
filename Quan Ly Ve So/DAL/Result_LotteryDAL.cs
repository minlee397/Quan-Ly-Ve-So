    using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DAL
{
    public class Result_LotteryDAL
    {
        public SqlDataReader LoadData()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_RESULT_LOTTERY", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }

        /*******************************/        
        public DataSet TypeList()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_id_TYPE_LOTTERY", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet PrizeList()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_id_PRIZE", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        /*******************************/

        public DataTable Find(string search_by, string value)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("find_RESULT_LOTTERY", ConnectDB.con);            
            cmd.Parameters.Add("@SEARCH_BY", SqlDbType.NVarChar).Value = search_by;
            cmd.Parameters.Add("@VALUE", SqlDbType.NVarChar).Value = value;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            ConnectDB.con.Close();
            return tb;
        }

        public void Insert(Result_LotteryDTO RSL)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert_RESULT_LOTTERY", ConnectDB.con);
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = RSL.ID_TYPE;
                cmd.Parameters.Add("@ID_PRIZE", SqlDbType.VarChar).Value = RSL.ID_PRIZE;
                cmd.Parameters.Add("@DATE_RESULT", SqlDbType.VarChar).Value = RSL.DATE_RESULT;
                cmd.Parameters.Add("@NUMBER_WIN", SqlDbType.VarChar).Value = RSL.NUMBER_WIN; 
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
        public void Edit(Result_LotteryDTO RSL)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("edit_RESULT_LOTTERY", ConnectDB.con);
                cmd.Parameters.Add("@ID_RESULT", SqlDbType.VarChar).Value = RSL.ID_RESULT;
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = RSL.ID_TYPE;
                cmd.Parameters.Add("@ID_PRIZE", SqlDbType.VarChar).Value = RSL.ID_PRIZE;
                cmd.Parameters.Add("@DATE_RESULT", SqlDbType.VarChar).Value = RSL.DATE_RESULT;
                cmd.Parameters.Add("@NUMBER_WIN", SqlDbType.VarChar).Value = RSL.NUMBER_WIN;
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
                SqlCommand cmd = new SqlCommand("delete_RESULT_LOTTERY", ConnectDB.con);
                cmd.Parameters.Add("@ID_RESULT", SqlDbType.VarChar).Value = id_delete;
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

        public SqlDataReader SearchNumberWin(Result_LotteryDTO RSL)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("search_WINNER_NUMBER", ConnectDB.con);
            cmd.Parameters.Add("@NUMBER_WIN", SqlDbType.VarChar).Value = RSL.NUMBER_WIN;
            cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = RSL.ID_TYPE;
            cmd.Parameters.Add("@DATE_RESULT", SqlDbType.DateTime).Value = RSL.DATE_RESULT;
            cmd.Parameters.Add("@LEN_NUMBER", SqlDbType.Int).Value = RSL.LEN_NUMBER;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }
    }
}