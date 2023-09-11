using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rental_movie_api.Entities;
using rental_movie_api.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace rental_movie_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _service;

        public MovieController(ILogger<MovieController> logger, IMovieService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// This method return a list of movies
        /// </summary>
        /// <returns>Movie</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAsync()
        {
            try
            {
                var movies = await _service.GetMovies();
                return Ok(movies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method returns a single one movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movie>> GetByIdAsync(int id)
        {
            try
            {
                var movie = await _service.GetMovieById(id);

                if (movie is null)
                {
                    return NotFound($"Movie not found.");
                }
                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                           "An error ocurred when requested method.");
            }            
        }

        /// <summary>
        /// This method inserts a new one movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostAsync(Movie movie)
        {
            try
            {
                if (movie is null || (movie is null && movie.GenreId == 0))
                    return BadRequest("Invalid data.");

                await _service.Create(movie);

                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method updates the movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> PutAsync(Movie movie)
        {
            try
            {
                if (movie is null)
                    return BadRequest("Invalid data.");

                await _service.Update(movie);

                return Ok(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                           "An error ocurred when requested method.");
            }
        }

        /// <summary>
        /// This method deletes a movie by id
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

        /// <summary>
        /// This method deletes a list of movies by list of ids separated by ,
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteManyAsync(int[] ids)
        {
            try
            {
                await _service.DeleteMany(ids);

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
