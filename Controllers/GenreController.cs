using Microsoft.AspNetCore.Mvc;
using Week8.models;
using Week8.repositories;

namespace Week8.Controllers {

    [ApiController]
    public class GenresController: ControllerBase {

        private readonly Week8DbContext _context;

        public GenresController(Week8DbContext context) {
            this._context = context;
        }

        [HttpGet("genres", Name = "GetGenres")]
        public List<Genre> GetGenres([FromQuery] string? criteria) {
            if (criteria != null) {
                string searchTerm = criteria.ToUpper();
                return this._context.Genres
                    .Where(genre => genre.Name.ToUpper().Contains(searchTerm))
                    .ToList();
            } else {
                return this._context.Genres.ToList();
            }
        }

    }

}