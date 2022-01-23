using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketPlatform.Data.Entity;
using TicketPlatform.Services.Request_Response;

namespace TicketPlatform.Services
{
    public interface  IBusLocationService
    {
        public Task<BusLocations> GetBusLocation(BusLocationRequest busLocationRequest, CancellationToken cancellationToken);


    }
}
