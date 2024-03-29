namespace Week8.models {

    public class Author {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public string Biography { get; set; }
        public string Nationality { get; set; }

        // Navigation properties
        public List<Book> Books { get; set; }

    }

}