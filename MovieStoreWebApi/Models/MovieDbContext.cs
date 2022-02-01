using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Models.Domain;
using System.Collections.Generic;

namespace MovieStoreWebApi.Models
{
    // Database
    public class MovieDbContext : DbContext
    {
        // Tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // string source = "ND-5CG9030M9M\\SQLEXPRESS";
            string source = "DESKTOP-P7G8DHC\\SQLEXPRESS";

            optionsBuilder.UseSqlServer($"Data Source = {source}; Initial Catalog = MovieStore; Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data into the database

            modelBuilder.Entity<Character>().HasData(new Character() { Id = 1, FullName = "Peter Parker", Alias = "Spider-Man", Gender = "Male", ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/4/48/Spider-Man_No_Way_Home_poster_011_Textless.jpg/revision/latest?cb=20220120195924" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 2, FullName = "Bruce Wayne", Alias = "Batman", Gender = "Male", ImageUrl = "https://static.wikia.nocookie.net/marvel_dc/images/7/76/Batman_Urban_Legends_Vol_1_5_Textless.jpg/revision/latest?cb=20210717062920" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 3, FullName = "Carol Susan Jane Danvers", Alias = "Captain Marvel", Gender = "Woman", ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/f/fe/CapMarvel-EndgameProfile.jpeg/revision/latest?cb=20190423175247" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 4, FullName = "Clark Kent", Alias = "Superman", Gender = "Man", ImageUrl = "https://static.wikia.nocookie.net/marvel_dc/images/a/a5/Superman_Vol_5_1_Textless.jpg/revision/latest?cb=20180711061148" });

            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 1, Name = "Marvel Cinematic Universe", Description = "Description for MCU"});
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 2, Name = "Marvel Cinematic Universe 2", Description = "Description for MCU 2" });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 3, Name = "DC Extended Universe", Description = "Description for DCEU" });

            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Title = "Movie 1", FranchiseId = 1, ReleaseYear = 2002, Genre = "Action, Drama"});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2, Title = "Movie 2", FranchiseId = 1, ReleaseYear = 1996, Genre = "Action, Drama"});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 3, Title = "Movie 3", FranchiseId = 3, ReleaseYear = 2006, Genre = "Action, Drama, Romance"});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 4, Title = "Movie 4", FranchiseId = 3, ReleaseYear = 2011, Genre = "Action, Drama, Comedy"});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 5, Title = "Movie 5", FranchiseId = 2, ReleaseYear = 2020, Genre = "Action, Drama"});

            // Characters and Movies have many to many relationship
            // A Character can play in many movies
            // A Movie can have many Characters

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Movies)
                .WithMany(m => m.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie", 
                    right => right.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    left => left.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    joinEntity => {
                        joinEntity.HasKey("CharacterId", "MovieId");
                        joinEntity.HasData(
                            new { CharacterId = 1, MovieId = 1 },
                            new { CharacterId = 1, MovieId = 2 },
                            new { CharacterId = 2, MovieId = 2 },
                            new { CharacterId = 3, MovieId = 4 }
                        );
                    });
        }
    }
}
