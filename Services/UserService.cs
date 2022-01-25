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

        public async Task<User> Authenticate(string username, string password)
        {
            // wrapped in "await Task.Run" to mimic fetching user from a db
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Name == username && x.Password == password));

            // on auth fail: null is returned because user is not found
            // on auth success: user object is returned
            return user;
        }

        public async Task<SessionResponse> GetSession(SessionModel sessionModel)
        {
            var response = await sessionServiceClient.GetSessionInfoAsync(sessionModel, CancellationToken.None);

            return response;
        }
    }
}
