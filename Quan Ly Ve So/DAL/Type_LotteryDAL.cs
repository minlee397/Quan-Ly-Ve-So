using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Quan_Ly_Ve_So.DTO;
using System.Data;

namespace Quan_Ly_Ve_So.DAL
{
    public class Type_LotteryDAL
    {    
        public SqlDataReader LoadData()
        {
            ConnectDB.con.Open();            
            SqlCommand cmd = new SqlCommand("load_TYPE_LOTTERY", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;        
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }            

        public DataTable Find(string search_by, string value)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("find_TYPE_LOTTERY", ConnectDB.con);
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

        public void Insert(Type_LotteryDTO TOP)
        {
            ConnectDB.con.Open();            
            try
            { 
                SqlCommand cmd = new SqlCommand("insert_TYPE_LOTTERY", ConnectDB.con);
                cmd.Parameters.Add("@CHANNEL", SqlDbType.NVarChar).Value = TOP.CHANNEL;
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

        public void Edit(Type_LotteryDTO TOP)
        {
            ConnectDB.con.Open();
            try
            {                
                SqlCommand cmd = new SqlCommand("edit_TYPE_LOTTERY", ConnectDB.con);
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = TOP.ID_TYPE;
                cmd.Parameters.Add("@CHANNEL", SqlDbType.NVarChar).Value = TOP.CHANNEL;
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
                SqlCommand cmd = new SqlCommand("delete_TYPE_LOTTERY", ConnectDB.con);
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