using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketPlatform.Data.Entity;
using TicketPlatform.Services.Request_Response;

namespace TicketPlatform.Services.Interface
{
    public interface  IBusLocationServiceRestClient
    {
        public Task<BusLocations> GetBusLocationAsync(BusLocationRequest busLocationRequest, CancellationToken cancellationToken);


    }
}
