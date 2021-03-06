﻿using System;
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
            SqlCommand cmd = new SqlCommand("load_id_TYPE_LOTTERY", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet AgencyList()
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("load_id_AGENCY", ConnectDB.con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataTable Find_mul_deal(DealDTO TOP)
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

        //FUNCTION NGHIEP VU

        // Lấy số lượng đăng kí vé số của một Đại Lý 
        public DataTable Get_Quantity_sign(string ID_AGENCY, string ID_TYPE)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("get_QUANTITY_SIGN", ConnectDB.con);
            cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = ID_AGENCY;
            cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = ID_TYPE;           
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            ConnectDB.con.Close();
            return ds;
        }



        // FUNCTION CRUD
        public DataTable Find(string search_by, string value)
        {
            ConnectDB.con.Open();
            SqlCommand cmd = new SqlCommand("find_DEAL", ConnectDB.con);            
            cmd.Parameters.Add("@SEARCH_BY", SqlDbType.VarChar).Value = search_by;
            cmd.Parameters.Add("@VALUE", SqlDbType.VarChar).Value = value;
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
        public void Delete(DealDTO TOP)
        {
            ConnectDB.con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("delete_DEAL", ConnectDB.con);
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = TOP.ID_TYPE;
                cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = TOP.ID_AGENCY;
                cmd.Parameters.Add("@DATE_RECEIVE", SqlDbType.VarChar).Value = TOP.DATE_RECEIVE;
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