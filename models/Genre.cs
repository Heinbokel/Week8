namespace Week8.models {

    public class Genre {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation Properties
        public List<Book> Books { get; set; }

    }

}