using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketPlatform.Data.Entity;
using TicketPlatform.Models;
using TicketPlatform.Services.Interface;
using TicketPlatform.Services.Request_Response;

namespace TicketPlatform.Services
{
    public class BusLocationServiceRestClient : IBusLocationServiceRestClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private int _timeout;
        private readonly string baseUrl;


        public BusLocationServiceRestClient(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;
            _configuration = configuration;

            _timeout = _configuration.GetValue<int>("ServiceTimeout");
            if (_timeout == 0)
                _timeout = 5;

            _httpClient.Timeout = TimeSpan.FromSeconds(_timeout);
            _httpClient.DefaultRequestHeaders.ConnectionClose = true;
            //var authInfo = "JEcYcEMyantZV095WVc3G2JtVjNZbWx1";
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);

            baseUrl = "https://v2-api.obilet.com";
        }
        public async Task<BusLocations> GetBusLocationAsync(BusLocationRequest busLocationRequest, CancellationToken cancellationToken)
        {
            //rest mımarısıne gore verı cekme
            var apiPath = $"{baseUrl}/api/location/getbuslocations?Data={busLocationRequest.Data}&session-id={busLocationRequest.SessionId}&device-id={busLocationRequest.DeviceId}&Date={busLocationRequest.Date}&language={busLocationRequest.Language}";
            var response = new BaseResponse();
            var requestHeaderObj = new RequestHeader
            {
                Authorization = "Basic JEcYcEMyantZV095WVc3G2JtVjNZbWx1="
            };

            try
            {
                using (var result = await _httpClient.PostAsync(apiPath, new StringContent(JsonConvert.SerializeObject(requestHeaderObj), Encoding.UTF8, "application/json"),cancellationToken).ConfigureAwait(false))
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    var mappedOrders = JsonConvert.DeserializeObject<BusLocations>(readTask.Result);

                    BusLocations locationResult = new BusLocations()
                    {
                        Data = (string)mappedOrders.Data

                    };

                    return locationResult;
                }
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
