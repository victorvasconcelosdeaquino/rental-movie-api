using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rental_movie_api.Entities;
using rental_movie_api.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace rental_movie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RentController : ControllerBase
    {
        private readonly ILogger<RentController> _logger;
        private readonly IRentService _service;

        public RentController(ILogger<RentController> logger, IRentService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// This method returns a list of rents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent>>> GetAsync()
        {
            try
            {
                var rents = await _service.GetRentals();
                return Ok(rents);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method returns a single one rent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genre>> GetByIdAsync(int id)
        {
            try
            {
                var rent = await _service.GetRentById(id);

                if (rent is null)
                {
                    return NotFound($"Rent not found.");
                }
                return Ok(rent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method creates a new one rent
        /// </summary>
        /// <param name="rent"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostAsync(Rent rent)
        {
            try
            {
                if (rent is null)
                    return BadRequest("Invalid data.");

                await _service.Create(rent);

                return Ok(rent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method updates a rent
        /// </summary>
        /// <param name="rent"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> PutAsync(Rent rent)
        {
            try
            {
                if (rent is null)
                    return BadRequest("Invalid data.");

                await _service.Update(rent);

                return Ok(rent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method deletes a single one rent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                await _service.Delete(id);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "An error ocurred when requested method.");
            }
        }
    }
}
