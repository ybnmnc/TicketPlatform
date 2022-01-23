using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Models
{
    public class IRequestContext
    {
        public int CustomerId { get; set; }
        public string SessionToken { get; set; }
        public string DeviceId { get; set; }

        public string SessionId { get; set; }

    }
}
