using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DTO
{
    public class ReceiptsDTO
    {
        public string ID_RECEIPTS { get; set; }
        public string ID_TYPE { get; set; }
        public string ID_AGENCY { get; set; }
        public string DATE_IND { get; set; }
        public string DATE_RECEIPTS { get; set; }
        public float PAYMENT { get; set; }        
    }
}