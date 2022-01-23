using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TicketPlatform.Data.Entity;
using TicketPlatform.Services.Request_Response;

namespace TicketPlatform.Services
{
    public class BusLocationService : IBusLocationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private int _timeout;
        private readonly string restUrl;


        public BusLocationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

            _timeout = _configuration.GetValue<int>("ServiceTimeout");
            if (_timeout == 0)
                _timeout = 5;

            _httpClient.Timeout = TimeSpan.FromSeconds(_timeout);
            _httpClient.DefaultRequestHeaders.ConnectionClose = true;

            restUrl = "https://v2-api.obilet.com";
        }
        public async Task<BusLocations> GetBusLocation(BusLocationRequest busLocationRequest, CancellationToken cancellationToken)
        {
            //rest mımarısıne gore verı cekme
            var apiPath = $"{restUrl}/api/location/getbuslocations/?Data={busLocationRequest.Data}&session-id={busLocationRequest.SessionId}&device-id={busLocationRequest.DeviceId}&Date={busLocationRequest.Date}&language={busLocationRequest.Language}";

            using (var result = await _httpClient.GetAsync(apiPath, cancellationToken).ConfigureAwait(false))
            {
                var readTask = result.Content.ReadAsStringAsync();
                var mappedOrders = JsonConvert.DeserializeObject<BusLocations>(readTask.Result);

                return mappedOrders;
            }
        }
    }
}
