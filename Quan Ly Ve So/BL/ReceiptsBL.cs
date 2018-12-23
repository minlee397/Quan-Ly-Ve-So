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
    public class ReceiptsBL
    {
        ReceiptsDAL R_DAL = new ReceiptsDAL();
        public SqlDataReader LoadData()
        {
            return R_DAL.LoadData();
        }

        public SqlDataReader Load_not_receipts()
        {
            return R_DAL.Load_not_receipts();
        }
        public DataSet IndebtednessList()
        {
            return R_DAL.IndebtednessList();
        }
        public DataTable find_Indebtedness(string value)
        {
            return R_DAL.find_Indebtedness(value);
        }

        // function CRUD

        public bool Insert(ReceiptsDTO RTO)
        {
            try
            {
                R_DAL.Insert(RTO);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool Delete(ReceiptsDTO ROP)
        {
            try
            {
                R_DAL.Delete(ROP);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}