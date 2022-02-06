using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;

namespace MovieStoreWebApi.Data
{
    // Database
    public class MovieStoreDbContext : DbContext
    {
        // Tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        public MovieStoreDbContext(DbContextOptions options) : base(options)
        {
        }

		public MovieStoreDbContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding data into the database

            modelBuilder.Entity<Character>().HasData(new Character() { Id = 1, FullName = "Peter Parker", Alias = "Spider-Man", Gender = "Male",
                ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/4/48/Spider-Man_No_Way_Home_poster_011_Textless.jpg/revision/latest?cb=20220120195924" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 2, FullName = "Carol Susan Jane Danvers", Alias = "Captain Marvel", Gender = "Female",
                ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/f/fe/CapMarvel-EndgameProfile.jpeg/revision/latest?cb=20190423175247" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 3, FullName = "Bruce Wayne", Alias = "Batman", Gender = "Male",
                ImageUrl = "https://static.wikia.nocookie.net/marvel_dc/images/7/76/Batman_Urban_Legends_Vol_1_5_Textless.jpg/revision/latest?cb=20210717062920" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 4, FullName = "Unknown", Alias = "The Joker", Gender = "Male",
                ImageUrl = "https://static.wikia.nocookie.net/marvel_dc/images/5/5d/Doomsday_Clock_Vol_1_5_Textless_Variant.jpg/revision/latest?cb=20180606215837" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 5, FullName = "Harry James Potter", Alias = "The Chosen One", Gender = "Male",
                ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/9/97/Harry_Potter.jpg/revision/latest/scale-to-width-down/360?cb=20140603201724" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 6, FullName = "Hermione Jean Granger", Alias = "Harry Potter (under disguise of Polyjuice Potion)", Gender = "Female",
                ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/3/34/Hermione_Granger.jpg/revision/latest/scale-to-width-down/1000?cb=20210522145306" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 7, FullName = "Aragorn II Elessar", Alias = "Thorongil", Gender = "Male",
                ImageUrl = "https://static.wikia.nocookie.net/lotr/images/b/b6/Aragorn_profile.jpg/revision/latest?cb=20170121121423" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 8, FullName = "Gandalf", Alias = "Old Greybeard", Gender = "Male",
                ImageUrl = "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest/scale-to-width-down/952?cb=20121110131754" });

            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 1, Name = "Harry Potter",
                Description = "Harry Potter is a film series based on the eponymous novels by J. K. Rowling. The series is distributed by Warner Bros." +
                " and consists of eight fantasy films, beginning with Harry Potter and the Philosopher's Stone (2001) and culminating with Harry Potter and the Deathly Hallows – Part 2 (2011)." });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 2, Name = "Marvel Cinematic Universe",
                Description = "The Marvel Cinematic Universe (MCU) is an American media franchise and shared universe centered on a series of superhero films produced by Marvel Studios." +
                " The films are based on characters that appear in American comic books published by Marvel Comics. The franchise also includes television series, short films, digital series, and literature." });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 3, Name = "DC Extended Universe",
                Description = "The DC Extended Universe is a collection of interconnected films and other media based on characters that appear in publications by DC Comics." +
                " The universe largely spans through films, though is touched on in many other mediums including comics, novels, guidebooks, short films, and video games." });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 4, Name = "Lord of the Rings",
                Description = "The Lord of the Rings is an epic high fantasy novel written by J.R.R. Tolkien, which was later fitted as a trilogy. The story began as a sequel" +
                " to Tolkien's earlier fantasy book The Hobbit, and soon developed into a much larger story." });

            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Title = "Harry Potter and the Philosopher's Stone", FranchiseId = 1, ReleaseYear = 2001, Genre = "Adventure, Family, Fantasy", Director = "Chris Columbus",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/7a/Harry_Potter_and_the_Philosopher%27s_Stone_banner.jpg", 
                TrailerUrl ="https://www.youtube.com/watch?v=VyHV0BRtdxo" });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2, Title = "Harry Potter and the Prisoner of Azkaban", FranchiseId = 1, ReleaseYear = 2004, Genre = "Adventure, Family, Fantasy", Director = "Alfonso Cuarón",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Prisoner_of_azkaban_UK_poster.jpg", 
                TrailerUrl ="https://www.youtube.com/watch?v=1ZdlAg3j8nI" });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 3, Title = "Harry Potter and the Order of the Phoenix", FranchiseId = 1, ReleaseYear = 2007, Genre = "Adventure, Family, Fantasy", Director = "David Yates",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e7/Harry_Potter_and_the_Order_of_the_Phoenix_poster.jpg", 
                TrailerUrl ="https://www.youtube.com/watch?v=y6ZW7KXaXYk" });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 4, Title = "Spider-Man: Far From Home", FranchiseId = 2, ReleaseYear = 2019, Genre = "Action, Superhero", Director = "Jon Watts",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/Spider-Man_Far_From_Home_poster.jpg", 
                TrailerUrl ="https://www.youtube.com/watch?v=Nt9L1jCKGnE" });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 5, Title = "Captain Marvel", FranchiseId = 2, ReleaseYear = 2019, Genre = "Action, Superhero", Director = "Anna Boden",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4e/Captain_Marvel_%28film%29_poster.jpg", 
                TrailerUrl ="https://www.youtube.com/watch?v=Z1BCujX3pw8" });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 6, Title = "Man of Steel", FranchiseId = 3, ReleaseYear = 2013, Genre = "Adventure, Action, Superhero", Director = "Zack Snyder",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/Man_of_Steel_%28film%29_poster.jpg", 
                TrailerUrl ="https://www.youtube.com/watch?v=T6DJcgm3wNY" });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 7, Title = "The Suicide Squad", FranchiseId = 3, ReleaseYear = 2021, Genre = "Adventure, Action, Superhero", Director = "James Gunn",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/0/06/The_Suicide_Squad_%28film%29_poster.jpg", 
                TrailerUrl ="https://www.youtube.com/watch?v=JuDLepNa7hw" });
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 8, Title = "The Lord of the Rings: The Two Towers", FranchiseId = 4, ReleaseYear = 2002, Genre = "Adventure, Fantasy", Director = "Peter Jackson",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d0/Lord_of_the_Rings_-_The_Two_Towers_%282002%29.jpg", 
                TrailerUrl ="https://www.youtube.com/watch?v=LbfMDwc4azU" });

            // Characters and movies have a many to many relationship
            // Character and movies have a one to many relationship
            // Movie and characters have a one to many relationship

            modelBuilder.Entity<Character>()
				.HasMany(c => c.Movies)
				.WithMany(m => m.Characters)
				.UsingEntity<Dictionary<string, object>>(
					"CharacterMovie",
					right => right.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
					left => left.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
					joinEntity =>
					{
						joinEntity.HasKey("CharacterId", "MovieId");
						joinEntity.HasData(
							new { CharacterId = 1, MovieId = 4 },
							new { CharacterId = 2, MovieId = 5 },
							new { CharacterId = 4, MovieId = 7 },
							new { CharacterId = 5, MovieId = 2 },
							new { CharacterId = 5, MovieId = 3 },
							new { CharacterId = 6, MovieId = 2 },
							new { CharacterId = 6, MovieId = 3 },
                            new { CharacterId = 7, MovieId = 8 },
                            new { CharacterId = 8, MovieId = 8 }
                        );
                    });
		}
    }
}
