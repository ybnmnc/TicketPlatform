using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketPlatform.Models;
using TicketPlatform.Models.RequestModel;
using TicketPlatform.Services.Interface;

namespace TicketPlatform.Services
{
    public class SessionServiceRestClient : ISessionServiceRestClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private int _timeout;
        private readonly string baseUrl;

        public SessionServiceRestClient(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _configuration = configuration;

            _timeout = _configuration.GetValue<int>("ServiceTimeout");
            if (_timeout == 0)
                _timeout = 5;

            _httpClient.Timeout = TimeSpan.FromSeconds(_timeout);
            _httpClient.DefaultRequestHeaders.ConnectionClose = true;
            //string  requestHeaderObj = "Basic JEcYcEMyantZV095WVc3G2JtVjNZbWx1="
            

            //_httpClient.DefaultRequestHeaders.Add("Authorization",)
            baseUrl = "https://v2-api.obilet.com";
        }
        public async Task<SessionResponse> GetSessionInfoAsync(SessionModel sessionModel, CancellationToken cancellationToken)
        {
            //rest mımarısıne gore verı cekme
            var apiPath = $"{baseUrl}/api/client/getsession?type={sessionModel.Type}&ip-address={sessionModel.Ip_Address}&version={sessionModel.Version}&equipment-id={sessionModel.EquipmentId}";
            var requestHeaderObj = new RequestHeader
            {
                Authorization = "Basic JEcYcEMyantZV095WVc3G2JtVjNZbWx1="
            };

            try
            {
                using (var result = await _httpClient.PostAsync(apiPath, new StringContent(JsonConvert.SerializeObject(requestHeaderObj), Encoding.UTF8, "application/json"), cancellationToken).ConfigureAwait(false))
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var mappedOrders = JsonConvert.DeserializeObject<SessionResponse>(readTask.Result);

                    SessionResponse sessionResponse = new SessionResponse()
                    {
                          SessionId= mappedOrders.SessionId,
                          DeviceId= mappedOrders.DeviceId

                    };

                    return sessionResponse;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
