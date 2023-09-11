using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using rental_movie_api.Entities;
using rental_movie_api.ServiceExtensions;

namespace rental_movie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _service;
        private readonly IConfiguration _configuration;

        public AuthController(ITokenService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        /// <summary>
        /// This method gets the token based on informations bellow
        /// Todo: move the user to the database
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult PostAsync(UserModel userModel)
        {
            if (userModel is null) return BadRequest("Invalid login");

            //Checks if the entered user and password is the same
            if (userModel.UserName == "vaquino" && userModel.Password == "americas123")
            {
                var tokenString = _service.GenerateToken(
                    _configuration["Jwt:Key"],
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    userModel);

                return Ok(new { token = tokenString });
            }
            else return BadRequest("Invalid login");
        }
    }
}
