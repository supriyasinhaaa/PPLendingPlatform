using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System;
using XYZAuthenticationService.BAL.Services;
using XYZAuthenticationService.DAL.Models;

namespace XYZAuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IServiceUser _serviceUser;
        public AuthenticationController(IAuthenticateService authenticateService, IServiceUser serviceUser)
        {
            _authenticateService = authenticateService;
            _serviceUser = serviceUser;
        }

        [HttpPost]
        [Route("Register")]

        public User Register([FromBody] User user)

        {

            //IActionResult response = Unauthorized();

            var userAdded = _serviceUser.AddUser(user);

            return userAdded;

        }
        [HttpPost]
        [Route("LogIn")]

        public IActionResult ALogIn(int userId, string password)
        {
            IActionResult response = Unauthorized();
            User user = new User()
            {
                Id = userId,
                PassWord = password

            };
             var userAuthenticated = _authenticateService.Authenticate(user);
            if (userAuthenticated != null)
            {
                return Ok(userAuthenticated);
            }
            return response;


        }
    }
}
