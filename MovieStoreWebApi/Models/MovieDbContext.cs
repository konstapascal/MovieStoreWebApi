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
            optionsBuilder.UseSqlServer("Data Source=ND-5CG9030M9M\\SQLEXPRESS;" +
                "Initial Catalog=MovieStore;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data into the database

            modelBuilder.Entity<Character>().HasData(new Character() { Id = 1, FullName = "Peter Parker", Alias = "Spiderman", Gender = "Male", ImageUrl = "https://i.annihil.us/u/prod/marvel/i/mg/7/70/59161b89c69ef/clean.jpg" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 2, FullName = "Peter Parker 2", Alias = "Spiderman 2", Gender = "Male", ImageUrl = "https://i.annihil.us/u/prod/marvel/i/mg/7/70/59161b89c69ef/clean.jpg" });
            modelBuilder.Entity<Character>().HasData(new Character() { Id = 3, FullName = "Peter Parker 3", Alias = "Spiderman 3", Gender = "Male", ImageUrl = "https://i.annihil.us/u/prod/marvel/i/mg/7/70/59161b89c69ef/clean.jpg" });

            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 1, Name = "Marvel Cinematic Universe", Description = "Description for MCU"});
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 2, Name = "Marvel Cinematic Universe 2", Description = "Description for MCU 2" });
            modelBuilder.Entity<Franchise>().HasData(new Franchise { Id = 3, Name = "Marvel Cinematic Universe 3", Description = "Description for MCU 3" });

            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 1, Title = "Spiderman 1", FranchiseId = 1, ReleaseYear = 2006, Genre = "Action, Drama"});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 2, Title = "Spiderman 2", FranchiseId = 1, ReleaseYear = 2006, Genre = "Action, Drama"});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 3, Title = "Spiderman 3", FranchiseId = 2, ReleaseYear = 2006, Genre = "Action, Drama"});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 4, Title = "Spiderman 4", FranchiseId = 2, ReleaseYear = 2006, Genre = "Action, Drama"});
            modelBuilder.Entity<Movie>().HasData(new Movie { Id = 5, Title = "Spiderman 5", FranchiseId = 3, ReleaseYear = 2006, Genre = "Action, Drama"});

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
