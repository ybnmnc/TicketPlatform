using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TicketPlatform.Models;
using TicketPlatform.Services;
using TicketPlatform.Services.Interface;

namespace TicketPlatform.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/")]
    [ApiController]
    public class UserController : AbstractController
    {
        private readonly IUserService _userService;

        //userservıce ımplemente edılmesı.
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //kullanıcı ıcın authentıcate metodu.
        [AllowAnonymous]
        [HttpPost("user/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        // apı sessıon metodu.
        [HttpPost("client/getsession")]
        public async Task<IActionResult> Session(dynamic requestBody)
        {
            SessionModel sessionModel = SessionModel.ConvertSessionInfoModel(requestBody.GetRawText());

            var users = await _userService.GetSession(sessionModel);
            return Ok(users);
        }
    }
}
