using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DAL
{
    public class PrizeDAL
    {
        public SqlDataReader LoadData()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_PRIZE", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }

        public DataTable Find(string search_by, string value)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("find_PRIZE", ConnectDB.con);
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

        public void Insert(PrizeDTO PRP)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert_PRIZE", ConnectDB.con);
                cmd.Parameters.Add("@NAME_PRIZE", SqlDbType.NVarChar).Value = PRP.NAME_PRIZE;
                cmd.Parameters.Add("@REWARD", SqlDbType.Float).Value = PRP.REWARD;
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

        public void Edit(PrizeDTO PRP)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("edit_PRIZE", ConnectDB.con);
                cmd.Parameters.Add("@ID_PRIZE", SqlDbType.NVarChar).Value = PRP.ID_PRIZE;
                cmd.Parameters.Add("@NAME_PRIZE", SqlDbType.NVarChar).Value = PRP.NAME_PRIZE;
                cmd.Parameters.Add("@REWARD", SqlDbType.Float).Value = PRP.REWARD;
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
                SqlCommand cmd = new SqlCommand("delete_PRIZE", ConnectDB.con);
                cmd.Parameters.Add("@ID_PRIZE", SqlDbType.VarChar).Value = id_delete;
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