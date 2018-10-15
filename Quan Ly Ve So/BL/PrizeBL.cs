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
    public class PrizeBL
    {
        PrizeDAL P_DAL = new PrizeDAL();
        public SqlDataReader LoadData()
        {
            return P_DAL.LoadData();
        }

        public DataTable Find(string search_by, string value)
        {
            return P_DAL.Find(search_by, value);
        }

        public bool Insert(PrizeDTO PRP)
        {
            try
            {
                P_DAL.Insert(PRP);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Edit(PrizeDTO PRP)
        {
            try
            {
                P_DAL.Edit(PRP);
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
                P_DAL.Delete(id_delete);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}