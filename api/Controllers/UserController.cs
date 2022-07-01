using System;
using api.Business;
using api.Models;
using api.Persistence;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : EntityController<User,UserDB, UserBusiness>
    {
        public UserController(ILogger<UserController> logger) : base(logger)
        {
            business = new UserBusiness();
        }

        [HttpPost]
		public IActionResult Login(Credential user)
		{
			var dbUser = business.Login(user);

			if (dbUser == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			return Ok(dbUser);
		}
    }
}
