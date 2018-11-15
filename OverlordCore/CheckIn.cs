using System;
using System.Collections.Generic;
using System.Text;

namespace OverlordCore
{
    public class CheckIn
    {
        public string MacAddress { get; set; }
        public string UserName { get; set; }
        public int MachineID { get; set; }
        public IEnumerable<Entry> Entries;
    }
}
