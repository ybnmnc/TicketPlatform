using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Services.RequestModel
{
    public class BusLocationRequest
    {
        public string Data { get; set; }
        public string DeviceId { get; set; }
        public string SessionId { get; set; }

        public string Language { get; set; }

        public string Date { get; set; }
    }
}
