using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketPlatform.Models;

namespace TicketPlatform.Services.Interface
{
    public interface ISessionServiceRestClient
    {
        Task<SessionResponse> GetSessionInfoAsync(SessionModel busLocationRequest, CancellationToken cancellationToken);
    }
}
