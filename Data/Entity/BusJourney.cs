using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Data.Entity
{
    public class BusJourney
    {
        public object Data { get; set; }
        public string SessionId { get; set; }
        public string DeviceId { get; set; }

        public DateTime Date { get; set; }
        public string Language { get; set; }

        public int OriginId { get; set; }

        public int DestinationId { get; set; }

        public string DepartureDate { get; set; }
    }
}
