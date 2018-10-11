using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Quan_Ly_Ve_So.DAL
{
    public class ConnectDB
    {
        public static SqlConnection con;
        static ConnectDB()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_QLSV"].ConnectionString);               
        }
    }
}