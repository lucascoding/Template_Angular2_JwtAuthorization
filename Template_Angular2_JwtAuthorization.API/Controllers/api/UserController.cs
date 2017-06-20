using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template_Angular2_JwtAuthorization.API.Controllers.api
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        [HttpGet("Register/{dealerCard}/{playerCard}")]
        public IActionResult RegisterUser(string dealerCard, string playerCard)
        {
            //return Ok(new BasicStrategyActionViewModel { BlackjackAction = BlackjackAction.DoubleDown.ToString(), Description = "testing you posted - " + dealerCard + " " + playerCard });
            return Ok();
        }
    }
    
}
