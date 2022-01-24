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
using TicketPlatform.Utility;

namespace TicketPlatform.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/location/")]
    [ApiController]
    public class TicketController : AbstractController
    {
        private readonly Services.BusLocationService busLocationService;
        private readonly IConfiguration configuration;
        private readonly ILogger<TicketController> logger;
        private readonly IRequestContext requestContext;
        public TicketController(ILogger<TicketController> logger, IConfiguration configuration)
        {
            logger = logger;
            configuration = configuration;
        }
        [HttpPost]
        [Route("getbuslocations")]
        public async Task<IActionResult> GetBusLOcations(dynamic requestBody)
        {
            BusLocationRequestModel requestModel = BusLocationRequestModel.ConvertBusLocationRequestModel(requestBody.GetRawText(), requestContext);

            Dictionary<string, object> responseBody = new Dictionary<string, object>();

            var result = busLocationService.GetBusLocation(requestBody, CancellationToken.None);

            responseBody.Add(ResponseConstants.BUS_LOCATION, result);

            return await PrepareResponseAsync((int)HttpStatusCode.OK, ResponseConstants.SUCCESS, responseBody);

        }
    }
}
