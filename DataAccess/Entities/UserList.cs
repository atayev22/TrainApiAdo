using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class UserList
    {
        public static string table = "TBL_USERLIST";
        public int USERID { get; set; }
        public string? NAME { get; set; }
        public string? SURNAME { get; set; }
        public string? PASSWORD { get; set; }
        public short STATUS { get; set; }
        
    }
}
