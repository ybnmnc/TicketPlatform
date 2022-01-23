﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TicketPlatform.Utility;

namespace TicketPlatform.Controllers
{
    public class AbstractController : Controller
    {
        public async Task<IActionResult> PrepareResponseAsync(int code, string msgKey, Dictionary<string, object> responseBody)
        {
            responseBody.Add(ResponseConstants.STATUS, new Status(code, ""));

            return this.Json(responseBody);
        }
    }
}
