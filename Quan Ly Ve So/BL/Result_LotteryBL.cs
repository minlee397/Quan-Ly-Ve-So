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
    public class Result_LotteryBL
    {
        Result_LotteryDAL R_DAL = new Result_LotteryDAL();
        public SqlDataReader LoadData()
        {
            return R_DAL.LoadData();
        }


        /****************************/

        public DataSet TypeList()
        {
            return R_DAL.TypeList();
        }
        public DataSet PrizeList()
        {
            return R_DAL.PrizeList();
        }
        /****************************/

        public DataTable Find(string search_by, string value)
        {
            return R_DAL.Find(search_by, value);
        }

        public bool Insert(Result_LotteryDTO RSL)
        {
            try
            {
                R_DAL.Insert(RSL);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Edit(Result_LotteryDTO RSL)
        {
            try
            {
                R_DAL.Edit(RSL);
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
                R_DAL.Delete(id_delete);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public SqlDataReader SearchNumberWin(Result_LotteryDTO RSL)
        {
            return R_DAL.SearchNumberWin(RSL);
        }
    }
}