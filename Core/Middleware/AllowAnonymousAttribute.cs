using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketPlatform.Core.Middleware
{
    //tum kullanıcı yetkı ıslemlerı ıcın yaratıldı.
    public class AllowAnonymousAttribute : Attribute
    {
        //kullanıcı yetkılendırmesı bıle olsa ıstenılen controller ıcın gırs yapılabılmeyı saglayacak gelıstırme yazılacak..
    }
}
