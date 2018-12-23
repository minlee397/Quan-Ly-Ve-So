using Quan_Ly_Ve_So.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.BL
{
    public class IndebtednessBL
    {
        IndebtednessDAL I_DAL = new IndebtednessDAL();

        //FUNCTION LOADDATA
        public SqlDataReader LoadData()
        {
            return I_DAL.LoadData();
        }

        //FUNCTION FIND
        public DataTable Find(string search_by, string value)
        {
            return I_DAL.Find(search_by, value);
        }
    }
}