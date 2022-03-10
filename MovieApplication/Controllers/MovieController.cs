using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> MovieList = new List<Movie>
        {
            new Movie
            {
                MovieId=1,
                MovieName="İnception",
                Category="Action",
                Comment="Nice movie",
                Description="Inception is a US science fiction film written and directed by Christopher Nolan.",
                State=false
            },
            new Movie
            {
                MovieId=2,
                MovieName="The Godfather",
                Category="Action",
                Comment="Nice movie",
                Description="The Godfather is a 1972 American epic crime film",
                State=true
            },
            new Movie
            {
                MovieId=3,
                MovieName="Harry Potter",
                Category="Action",
                Comment="Nice movie",
                Description="Harry James Potter is a fictional character and the titular protagonist in J. K. Rowling's series of eponymous novels.",
                 State=true
            },
            new Movie
            {
                MovieId=4,
                MovieName="Star Sars ",
                Category="Action",
                Comment="Nice movie",
                Description="The story of the original trilogy focuses on Luke Skywalker's quest to become a Jedi, his struggle with the evil Imperial agent Darth Vader, " +
                "and the struggle of the Rebel Alliance to free the galaxy from the clutches of the Galactic Empire.",
                 State=false
            }
        };

        [HttpGet]
           public IActionResult GetAll()
        {
            return Ok(MovieList);
        }


        [HttpGet("{id}") ]
        public IActionResult GetById(int id)
        {
            var movie = MovieList.SingleOrDefault(m => m.MovieId == id);
            if (movie is null)
            {
                return BadRequest();
            }
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Movie movie)
        {
            var movieExist = MovieList.SingleOrDefault(m => m.MovieId == movie.MovieId);
            if (movieExist is null)
            {
                return BadRequest();
            }
            MovieList.Add(movie);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Movie movie)
        {
            var movieExist = MovieList.SingleOrDefault(m => m.MovieId == id);
            if (movieExist is null)
            {
                return BadRequest();
            }
            movieExist.MovieName = movie.MovieName != default ? movie.MovieName : movieExist.MovieName;
            movieExist.Comment = movie.Comment != default ? movie.Comment : movieExist.Comment;
            movieExist.Category = movie.Category != default ? movie.Category : movieExist.Category;
            movieExist.Description = movie.Description != default ? movie.Description : movieExist.Description;
            movieExist.Time = movie.Time != default ? movie.Time : movieExist.Time;
            return Ok();
            
        }
        [HttpPatch ("{id}")]
        public IActionResult UpdateStatus(int id, [FromBody] Movie movie)
        {
            var movieExist = MovieList.SingleOrDefault(m => m.MovieId == id);
            if (movie is null)
            {
                return BadRequest();
            }
            movieExist.State =movie.State;
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movieExist = MovieList.SingleOrDefault(m => m.MovieId == id);
            if (movieExist is null)
            {
                return BadRequest();
            }

            MovieList.Remove(movieExist);
            return Ok();
        }

        [HttpGet("pagenotfound")]
        public IActionResult PageNotFound()
        {
            return StatusCode(404);
        }
        [HttpGet("internalservererror")]
        public IActionResult InternalServerError()
        {
            return StatusCode(500);
        }




    }
}
