using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Data.Entity
{
    public class BusLocations
    {
        public object Data { get;set; }
        public string SessionId { get; set; }
        public string DeviceId { get; set; }

        public DateTime Date { get; set; }
        public string Language { get; set; }
    }
}
