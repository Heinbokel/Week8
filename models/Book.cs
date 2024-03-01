using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Week8.models {

    public class Book {
        public int Id { get; set; }


        [MaxLength(150)]
        public string Title { get; set; }


        [MaxLength(500)]
        public string Synopsis { get; set; }

        public DateOnly PublicationDate { get; set; }


        [MaxLength(13)]
        public string ISBN { get; set; }

        // Navigation Properties to tell EF what relationships exist
        // between the book and these other entities.
        public List<Author> Authors { get; set; }

        [JsonIgnore]
        public List<Genre> Genres { get; set; }
        public List<BookImage> BookImages { get; set; }
    }

}