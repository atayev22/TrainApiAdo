using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OrderList
    {
        public static string table = "TBL_ORDERLIST";
        public int TRN_ORDERID { get; set; }
        public string? TRN_ORDERNOTE { get; set; }
        public byte TRN_ORDERSTATUS { get; set; }
        public int USERID { get; set; }
        
    }
}
