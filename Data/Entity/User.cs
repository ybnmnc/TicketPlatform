using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketPlatform.Data.Entity
{
    public class User
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

    }
}
