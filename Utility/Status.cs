using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Utility
{
    public class Status
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public Status(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public Status()
        {
        }
    }
}
