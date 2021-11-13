using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRaterApi.Models;

namespace MovieRaterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private MovieDbContext _context;
        public MovieController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieEdit model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Add(new Movie
            {
                Title = model.Title, 
                ReleaseDate = model.ReleaseDate
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMovie()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if(movie == null)
            {
                return NotFound("Object null");
            }
            return Ok(movie);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] int id, [FromForm] MovieEdit model)
        {
                var movie = await _context.Movies.FindAsync(id);
                if(movie == null)
                {
                    return NotFound("Object null");
                }
                if(ModelState.IsValid)
                {
                    movie.Title = model.Title;
                    movie.ReleaseDate = model.ReleaseDate;
                }
                await _context.SaveChangesAsync();
                var updatedMovie = await _context.Movies.FindAsync(id);
                return Ok(updatedMovie);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return Ok(movie);
            
        }

    }
}