using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DTO
{
    public class DealDTO
    {
        public string ID_TYPE { get; set; }
        public string ID_AGENCY { get; set; }
        public string QUANTITY_RECEIVE{ get; set; }
        public string QUANTITY_SELL { get; set; }
        public string DATE_RECEIVE { get; set; }
        public string COMMISSION { get; set; }
    }
}