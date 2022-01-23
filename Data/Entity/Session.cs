using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Data.Entity
{
    public class Session
    {
        public int Type { get; set; }
        public string Ip_Address { get; set; }
        public string Version { get; set; }
        public string EquipmentId { get; set; }
    }
}
