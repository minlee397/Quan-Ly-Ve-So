using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DAL
{
    public class ReceiptsDAL
    {
        public SqlDataReader LoadData()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_RECEIPTS", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }
        public SqlDataReader Load_not_receipts()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_NOT_RECEIPTS", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }

        public DataSet IndebtednessList()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_id_INDEBTEDNESS", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable find_Indebtedness(string value)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("find_id_INDEBTEDNESS", ConnectDB.con);
            cmd.Connection = ConnectDB.con;           
            cmd.Parameters.Add("@VALUE", SqlDbType.VarChar).Value = value;            
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            ConnectDB.con.Close();
            return tb;
        }

        public void Insert(ReceiptsDTO RTO)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert_RECEIPTS", ConnectDB.con);
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = RTO.ID_TYPE;
                cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = RTO.ID_AGENCY;
                cmd.Parameters.Add("@DATE_IND", SqlDbType.VarChar).Value = RTO.DATE_IND;
                cmd.Parameters.Add("@DATE_RECEIPTS", SqlDbType.VarChar).Value = RTO.DATE_RECEIPTS;
                cmd.Parameters.Add("@PAYMENT", SqlDbType.Float).Value = RTO.PAYMENT;                
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

        public void Delete(ReceiptsDTO ROP)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("delete_RECEIPTS", ConnectDB.con);
                cmd.Parameters.Add("@ID_RECEIPTS", SqlDbType.VarChar).Value = ROP.ID_RECEIPTS;              
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