using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quan_Ly_Ve_So.DAL;
using Quan_Ly_Ve_So.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Quan_Ly_Ve_So.BL
{
    public class DealBL
    {
        DealDAL D_DAL = new DealDAL();
        public SqlDataReader LoadData()
        {
            return D_DAL.LoadData();
        }
        public DataSet TypeList()
        {
            return D_DAL.TypeList();
        }
        public DataSet AgencyList()
        {
            return D_DAL.AgencyList();
        }
        public DataTable Find_mul_deal(DealDTO TOP)
        {
            return D_DAL.Find_mul_deal(TOP);
        }

        public DataTable Find(string search_by, string value)
        {
            return D_DAL.Find(search_by, value);
        }

        public bool Insert(DealDTO DO)
        {
            try
            {
                D_DAL.Insert(DO);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Edit(DealDTO DO)
        {
            try
            {
                D_DAL.Edit(DO);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(DealDTO TOP)
        {
            try
            {
                D_DAL.Delete(TOP);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}