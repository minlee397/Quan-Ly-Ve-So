using Quan_Ly_Ve_So.DAL;
using Quan_Ly_Ve_So.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.BL
{
	public class SignUp_LotteryBL
	{
		SignUp_LotteryDAL SUL_DAL = new SignUp_LotteryDAL();

		public SqlDataReader LoadData()
		{
			return SUL_DAL.LoadData();
		}
        public DataSet AgencyList()
        {
            return SUL_DAL.AgencyList();
        }
        public DataSet TypeList()
        {
            return SUL_DAL.TypeList();
        }
        public DataTable Find(string search_by, string value)
		{
			return SUL_DAL.Find(search_by, value);
		}

		public bool Insert(SignUp_LotteryDTO SUL)
		{
			try
			{
				SUL_DAL.Insert(SUL);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public bool Edit(SignUp_LotteryDTO SUL)
		{
			try
			{
				SUL_DAL.Edit(SUL);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		public bool Delete(string id_delete)
		{
			try
			{
				SUL_DAL.Delete(id_delete);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}
	}
}