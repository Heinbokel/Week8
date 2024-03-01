using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week8.models;
using Week8.repositories;

namespace Week8.Controllers
{

    [ApiController]
    public class GenresController : ControllerBase
    {

        private readonly Week8DbContext _context;

        public GenresController(Week8DbContext context)
        {
            this._context = context;
        }

        [HttpGet("genres", Name = "GetGenres")]
        public List<Genre> GetGenres([FromQuery] string? criteria)
        {
            if (criteria != null)
            {
                string searchTerm = criteria.ToUpper();
                return this._context.Genres
                    .Where(genre => genre.Name.ToUpper().Contains(searchTerm))
                    .ToList();
            }
            else
            {
                return this._context.Genres.ToList();
            }
        }

        [HttpGet("genres/{genreId}", Name = "GetGenreById")]
        public Genre? GetGenreById(int genreId)
        {
            return this._context.Genres
                .Include(genre => genre.Books)
                .Where(genre => genre.Id == genreId)
                .FirstOrDefault();
        }

        [HttpDelete("genres/{genreId}", Name = "DeleteGenreById")]
        public void DeleteGenreById(int genreId)
        {
            Genre? genreToDelete = this._context.Genres
                .Where(genre => genre.Id == genreId)
                .FirstOrDefault();

            if (genreToDelete != null)
            {
                this._context.Genres.Remove(genreToDelete);
                this._context.SaveChanges();
            }
            else
            {
                throw new Exception($"Hey this genre with ID {genreId} didn't exist");
            }
        }

        [HttpPost("genres", Name = "CreateGenre")]
        public Genre CreateGenre([FromBody] GenreCreateRequest request)
        {
            Genre genreToCreate = new Genre
            {
                Name = request.Name,
                Description = request.Description
            };

            this._context.Genres.Add(genreToCreate);
            this._context.SaveChanges();

            return genreToCreate;
        }

        [HttpPut("genres/{genreId}", Name = "UpdateGenre")]
        public void UpdateGenre([FromBody] GenreCreateRequest request, int genreId)
        {
            // This should be using a GenreUpdateRequest as the form to update a genre
            // Maybe quite different than the form to Create a Genre.
            Genre? genreToUpdate = this._context.Genres
                .Find(genreId);

            if (genreToUpdate != null)
            {
                genreToUpdate.Name = request.Name;
                genreToUpdate.Description = request.Description;
                this._context.SaveChanges();
            } else {
                throw new Exception("Genre was not found to update");
            }
        }
    }

}