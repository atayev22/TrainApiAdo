using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   
    public class TransportList

    {
        public static string table = "TBL_TRANSPORTLIST";

        public int TRN_ID { get; set; }
        public string? TRN_PREFIX { get; set; }
        public int TRN_NO { get; set; }
        public Int16 TRN_OWNER { get; set; }
        public int TRN_TRTYPE { get; set; }
        public int TRN_TRCAT { get; set; }
        public Int16 TRN_TYPE { get; set; }
        public int TRN_FULLEMPTY { get; set; }
        public int TRN_COUNT { get; set; }
        public int TRN_PLATOWNER { get; set; }
        public int TRN_PLATTYPE { get; set; }
        public int TRN_PLATCOUNT { get; set; }
        public byte TRN_STATUS { get; set; }     
        public int TRN_ORDID { get; set; }


    }
}
