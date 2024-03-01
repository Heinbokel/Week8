using Microsoft.EntityFrameworkCore;
using Week8.models;

namespace Week8.repositories {

    public class Week8DbContext: DbContext {
        private readonly IConfiguration _configuration;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookImage> BookImages { get; set; }

        public Week8DbContext(IConfiguration configuration) {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            // optionsBuilder.UseSqlite("Week8.db");

            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre{Id = 1, Name = "Fantasy", Description = "Epic Adventures and Quests"},
                new Genre{Id = 2, Name = "Fiction", Description = "Fiction Description"},
                new Genre{Id = 3, Name = "Thriller", Description = "Thriller Description"},
                new Genre{Id = 4, Name = "Mystery", Description = "Mystery Description"}
            );
        }
    }

}