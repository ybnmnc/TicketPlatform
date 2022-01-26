using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Models
{
    public class BaseResponse
    {
        // temel sevıye de apıden donen degerlerde kullanılması ıcın olusturuldu.
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; }
    }
}
