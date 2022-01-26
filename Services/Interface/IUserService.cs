using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketPlatform.Data.Entity;
using TicketPlatform.Models;

namespace TicketPlatform.Services.Interface
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<SessionResponse> GetSession(SessionModel sessionModel);
    }
}
