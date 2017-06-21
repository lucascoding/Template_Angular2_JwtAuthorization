using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Template_Angular2_JwtAuthorization.API.Data;
using Template_Angular2_JwtAuthorization.API.ViewModel;

namespace Template_Angular2_JwtAuthorization.API.Controllers.api
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("Register/{dealerCard}/{playerCard}")]
        public IActionResult RegisterUser(string dealerCard, string playerCard)
        {
            return Ok();
        }
        
        [HttpPost("Log")]
        public IActionResult LogUser([FromBody] UserViewModel user)
        {
            return Json(_userRepo.LogUser(user));
        }



    }

}
