using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Subject
    {
        public static string table = "T_SUBJECT";
        public int S_ID { get; set; }
        public int S_EX_ID { get; set; }
        public string S_NAME { get; set; } = string.Empty;
        public short S_QUESTIONCOUNT { get; set; }
        public short S_QUESTIONEASYCOUNT { get; set; }
        public short S_QUESTIONMEDIUMCOUNT { get; set; }
        public short S_QUESTIONHIGHCOUNT { get; set; }
        public string S_COLOR { get; set; } = string.Empty;
        public string S_ICON { get; set; } = string.Empty;
        public byte S_STATUS { get; set; }
        public string S_NOTE { get; set; } = string.Empty;
    }
}
