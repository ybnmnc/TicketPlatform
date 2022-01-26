using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TicketPlatform.Services;
using TicketPlatform.Services.Interface;

namespace TicketPlatform.Core.Middleware
{
    public class BasicAuthMiddleware
    {
        // ara katman kulanılması.request => response arasında handle edılecek ıslemler ıcın yazılmıstır.
        //Authorzatın ıle => kullanıcı adı ve sıfre kontrolu => yatkı okey ıse response donmesı logıcı.

        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                var username = credentials[0];
                var password = credentials[1];
                context.Items["User"] = await userService.Authenticate(username, password);
            }
            catch
            {
            }

            await _next(context);
        }
    }
}
