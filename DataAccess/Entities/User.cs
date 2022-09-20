using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public static string table = "Users";

        public string Name { get; set; }=string.Empty;
        public byte[]? PasswordHash { get; set; }
        public string role { get; set; } = string.Empty;


    }
}
