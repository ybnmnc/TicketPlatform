using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Models
{
    public class SessionResponse
    {
        public int Type { get; set; }

        public string Ip_Address { get; set; }
        public string Status { get; set; }
        public string SessionId { get; set; }

        public string DeviceId { get; set; }

        public string Message { get; set; }

    }
}
