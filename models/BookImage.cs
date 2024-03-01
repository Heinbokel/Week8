namespace Week8.models {

    public class BookImage {

        public int Id { get; set; }
        public string ImageUrl { get; set; }

        // Navigation Properties for MANY BOOK IMAGES TO ONE BOOK
        public int BookId { get; set; }
        public Book Book { get; set; }
    }

}