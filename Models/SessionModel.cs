using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketPlatform.Exceptions;
using TicketPlatform.Utility;

namespace TicketPlatform.Models
{
    public class SessionModel
    {
        public int Type { get; set; }
        public string Ip_Address { get; set; }
        public string Version { get; set; }
        public string EquipmentId { get; set; }

        public static SessionModel ConvertSessionInfoModel(string requestBody)
        {
            SessionModel model = new SessionModel();

            JObject obj = JObject.Parse(requestBody);

            if (obj.ContainsKey(RequestConstants.TYPE))
            {
                int type = obj[RequestConstants.TYPE].ToObject<int>();

                model.Type = type;
            }
            else
            {
                throw new RequiredException("error.missing.type");
            }
            if (!String.IsNullOrEmpty((string)obj.SelectToken("connection.ip-address")))
            {
                string IpAdress = obj.SelectToken("connection.ip-address").ToObject<string>();
                model.Ip_Address = IpAdress;
            }
            else
            {
                throw new RequiredException("error.missing.Ipadress");
            }
            if (!String.IsNullOrEmpty((string)obj.SelectToken("application.version")))
            {
                string version = obj.SelectToken("application.version").ToObject<string>();
                model.Version = version;
            }
            else
            {
                throw new RequiredException("error.missing.version");
            }
            if (!String.IsNullOrEmpty((string)obj.SelectToken("application.equipment-id")))
            {
                string equıpmentId = obj.SelectToken("application.equipment-id").ToObject<string>();
                model.EquipmentId = equıpmentId;
            }
            else
            {
                throw new RequiredException("error.missing.equıpmentId");
            }


            return model;

        }




    }
}
