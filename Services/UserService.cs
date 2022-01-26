using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketPlatform.Data.Entity;
using TicketPlatform.Models;
using TicketPlatform.Services.Interface;

namespace TicketPlatform.Services
{
    public class UserService : IUserService
    {
        private readonly ISessionServiceRestClient sessionServiceClient;
        private readonly IConfiguration configuration;
        public UserService(ISessionServiceRestClient sessionServiceClient, IConfiguration configuration)
        {
            this.sessionServiceClient = sessionServiceClient;
            this.configuration = configuration;
        }

        private List<User> _users = new List<User>
    {
        new User { Id = 1, Name = "Test1", Password = "test" }
    };

        // user kaydını tuttugumuz verı ıle requestten gelen verı karsılastırması.
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Name == username && x.Password == password));
            return user;
        }

        //getsessıon ıcın servıs uzerınden rest apı cagrılması.
        public async Task<SessionResponse> GetSession(SessionModel sessionModel)
        {
            var response = await sessionServiceClient.GetSessionInfoAsync(sessionModel, CancellationToken.None);

            return response;
        }
    }
}
