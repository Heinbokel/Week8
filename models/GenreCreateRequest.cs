using System.ComponentModel.DataAnnotations;

namespace Week8.models {

    public class GenreCreateRequest {

        [MaxLength(50, ErrorMessage = "Name must be 50 characters or less.")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Description must be 100 characters or less.")]
        public string Description { get; set; }

    }

}