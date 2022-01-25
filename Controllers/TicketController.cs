using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TicketPlatform.Data.Entity;
using TicketPlatform.Models;
using TicketPlatform.Services;
using TicketPlatform.Services.Interface;
using TicketPlatform.Services.Request_Response;
using TicketPlatform.Utility;

namespace TicketPlatform.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/location/")]
    [ApiController]
    public class TicketController : AbstractController
    {
        private readonly IBusLocationServiceRestClient  _serviceRestClient;
        private readonly IConfiguration configuration;
        private readonly ILogger<TicketController> logger;
        private readonly IRequestContext requestContext;
        public TicketController(ILogger<TicketController> logger,
            IConfiguration configuration,
           IBusLocationServiceRestClient   serviceRestClient)
        {
            this.logger = logger;
            this.configuration = configuration;
            this._serviceRestClient = serviceRestClient;
        }
        [HttpPost]
        [Route("getbuslocations")]
        public async Task<IActionResult> GetBusLOcations(dynamic requestBody)
        {
            BusLocationRequestModel requestModel = BusLocationRequestModel.ConvertBusLocationRequestModel(requestBody.GetRawText(), requestContext);

            Dictionary<string, object> responseBody = new Dictionary<string, object>();

            var result = await _serviceRestClient.GetBusLocationAsync(new BusLocationRequest
            {
                Data = (string)requestModel.Data,
                DeviceId = requestModel.DeviceId,
                SessionId = requestModel.SessionId,
                Language = requestModel.Language,
                Date=requestModel.Date.ToString()
            },
                CancellationToken.None);

            responseBody.Add(ResponseConstants.BUS_LOCATION, result);

            return await PrepareResponseAsync((int)HttpStatusCode.OK, ResponseConstants.SUCCESS, responseBody);

        }
    }
}
