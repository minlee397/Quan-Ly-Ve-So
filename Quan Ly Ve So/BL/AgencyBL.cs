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
    public class AgencyBL
    {
        AgencyDAL A_DAL = new AgencyDAL();
        public SqlDataReader LoadData()
        {
            return A_DAL.LoadData();
        }

        public DataTable Find(string search_by, string value)
        {
            return A_DAL.Find(search_by, value);
        }

        public bool Insert(AgencyDTO AD)
        {
            try
            {
                A_DAL.Insert(AD);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Edit(AgencyDTO AD)
        {
            try
            {
                A_DAL.Edit(AD);
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
                A_DAL.Delete(id_delete);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}