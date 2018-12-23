using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DAL
{
	public class SignUp_LotteryDAL
	{

		public SqlDataReader LoadData()
		{
			ConnectDB.con.Open();
			SqlCommand cmd = new SqlCommand("load_SIGN_UP_LOTTERY", ConnectDB.con);
			cmd.CommandType = CommandType.StoredProcedure;
			SqlDataReader rd = cmd.ExecuteReader();
			return rd;
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
        public DataTable Find(string search_by, string value)
		{
			ConnectDB.con.Open();
			SqlCommand cmd = new SqlCommand("find_SIGN_UP_LOTTERY", ConnectDB.con);
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

		public void Insert(SignUp_LotteryDTO TOP)
		{
			ConnectDB.con.Open();
			try
			{
				SqlCommand cmd = new SqlCommand("insert_SIGN_UP_LOTTERY", ConnectDB.con);
				cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = TOP.ID_AGENCY;
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = TOP.ID_TYPE;
                cmd.Parameters.Add("@DATE_SIGN", SqlDbType.VarChar).Value = TOP.DATE_SIGN;
				cmd.Parameters.Add("@QUANTITY", SqlDbType.Int).Value = TOP.QUANITY_SIGN;
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

		public void Edit(SignUp_LotteryDTO TOP)
		{
			ConnectDB.con.Open();
			try
			{
				SqlCommand cmd = new SqlCommand("edit_SIGN_UP_LOTTERY", ConnectDB.con);
				cmd.Parameters.Add("@ID_SIGN", SqlDbType.VarChar).Value = TOP.ID_SIGN;
				cmd.Parameters.Add("@ID_AGENCY", SqlDbType.VarChar).Value = TOP.ID_AGENCY;
                cmd.Parameters.Add("@ID_TYPE", SqlDbType.VarChar).Value = TOP.ID_TYPE;
                cmd.Parameters.Add("@DATE_SIGN", SqlDbType.VarChar).Value = TOP.DATE_SIGN;
				cmd.Parameters.Add("@QUANTITY_SIGN", SqlDbType.Int).Value = TOP.QUANITY_SIGN;
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
				SqlCommand cmd = new SqlCommand("delete_SIGN_UP_LOTTERY", ConnectDB.con);
				cmd.Parameters.Add("@ID_SIGN", SqlDbType.VarChar).Value = id_delete;
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