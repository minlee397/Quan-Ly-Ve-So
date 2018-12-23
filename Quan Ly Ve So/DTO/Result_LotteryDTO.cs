using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quan_Ly_Ve_So.DTO
{
    public class Result_LotteryDTO
    {
        public string ID_RESULT { get; set; }
        public string ID_TYPE { get; set; }
        public string ID_PRIZE { get; set; }
        public string DATE_RESULT { get; set; }
        public string NUMBER_WIN { get; set; }
        public int LEN_NUMBER { get; set; }
    }
}