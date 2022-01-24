﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketPlatform.Exceptions;
using TicketPlatform.Utility;

namespace TicketPlatform.Models
{
    public class BusLocationRequestModel
    {
        public object Data { get; set; }
        public string SessionId { get; set; }
        public string DeviceId { get; set; }
        public DateTime Date { get; set; }
        public string Language { get; set; }

        public static BusLocationRequestModel ConvertBusLocationRequestModel(string requestBody, IRequestContext requestContext)
        {
            BusLocationRequestModel model = new BusLocationRequestModel();

            JObject obj = JObject.Parse(requestBody);

            if (obj.ContainsKey(RequestConstants.DATA))
            {
                string data = obj[RequestConstants.DATA].ToObject<string>();

                model.Data = data;
            }
            else
            {
                throw new RequiredException("error.missing.data");
            }
            if (!String.IsNullOrEmpty((string)obj.SelectToken("device-session.device-id")))
            {
                string deviceId = obj.SelectToken("device-session.device-id").ToObject<string>();
                model.DeviceId = deviceId;
            }
            else
            {
                throw new RequiredException("error.missing.deviceId");
            }
            if (!String.IsNullOrEmpty((string)obj.SelectToken("device-session.session-id")))
            {
                string sessionId = obj.SelectToken("device-session.session-id").ToObject<string>();
                model.SessionId = sessionId;
            }
            else
            {
                throw new RequiredException("error.missing.sessionId");
            }

            return model;
        }
    }
}
