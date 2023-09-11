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
    public class GenreController : ControllerBase
    {
        private readonly ILogger<GenreController> _logger;
        private readonly IGenreService _service;

        public GenreController(ILogger<GenreController> logger, IGenreService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// This method return a list of genres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAsync()
        {
            try
            {
                var genres = await _service.GetGenres();
                return Ok(genres);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method return a genre by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genre>> GetByIdAsync(int id)
        {
            try
            {
                var genre = await _service.GetGenreById(id);

                if (genre is null)
                {
                    return NotFound($"Genre not found.");
                }
                return Ok(genre);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method inserts a new one genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostAsync(Genre genre)
        {
            try
            {
                if (genre is null)
                    return BadRequest("Invalid data.");

                await _service.Create(genre);

                return Ok(genre);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method updates a genre 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> PutAsync(Genre genre)
        {
            try
            {
                if (genre is null)
                    return BadRequest("Invalid data.");

                await _service.Update(genre);

                return Ok(genre);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method deletes a genre by id
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
