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
    public class Type_LotteryBL
    {
        Type_LotteryDAL T_DAL = new Type_LotteryDAL();
        public SqlDataReader LoadData()
        {                           
            return T_DAL.LoadData();
        }

        public DataTable Find(string search_by, string value)
        {
            return T_DAL.Find(search_by,value);
        }

        public bool Insert(Type_LotteryDTO TLO)
        {            
            try
            {                
                T_DAL.Insert(TLO);
            }
            catch (Exception ex)
            {                
                return false;
            }
            return true;
        }

        public bool Edit(Type_LotteryDTO TLO)
        {
            try
            {
                T_DAL.Edit(TLO);
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
                T_DAL.Delete(id_delete);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }       
    }
}