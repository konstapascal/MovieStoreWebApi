﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStoreWebApi.Data;

namespace MovieStoreWebApi.Migrations
{
    [DbContext(typeof(MovieStoreDbContext))]
    [Migration("20220204210510_MoreSeedData")]
    partial class MoreSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieId = 4
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 5
                        },
                        new
                        {
                            CharacterId = 4,
                            MovieId = 7
                        },
                        new
                        {
                            CharacterId = 5,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 5,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 6,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 6,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 7,
                            MovieId = 8
                        },
                        new
                        {
                            CharacterId = 8,
                            MovieId = 8
                        });
                });

            modelBuilder.Entity("MovieStoreWebApi.Models.Domain.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Spider-Man",
                            FullName = "Peter Parker",
                            Gender = "Male",
                            ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/4/48/Spider-Man_No_Way_Home_poster_011_Textless.jpg/revision/latest?cb=20220120195924"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Captain Marvel",
                            FullName = "Carol Susan Jane Danvers",
                            Gender = "Female",
                            ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/f/fe/CapMarvel-EndgameProfile.jpeg/revision/latest?cb=20190423175247"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Batman",
                            FullName = "Bruce Wayne",
                            Gender = "Male",
                            ImageUrl = "https://static.wikia.nocookie.net/marvel_dc/images/7/76/Batman_Urban_Legends_Vol_1_5_Textless.jpg/revision/latest?cb=20210717062920"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "The Joker",
                            FullName = "Unknown",
                            Gender = "Male",
                            ImageUrl = "https://static.wikia.nocookie.net/marvel_dc/images/5/5d/Doomsday_Clock_Vol_1_5_Textless_Variant.jpg/revision/latest?cb=20180606215837"
                        },
                        new
                        {
                            Id = 5,
                            Alias = "The Chosen One",
                            FullName = "Harry James Potter",
                            Gender = "Male",
                            ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/9/97/Harry_Potter.jpg/revision/latest/scale-to-width-down/360?cb=20140603201724"
                        },
                        new
                        {
                            Id = 6,
                            Alias = "Harry Potter (under disguise of Polyjuice Potion)",
                            FullName = "Hermione Jean Granger",
                            Gender = "Female",
                            ImageUrl = "https://static.wikia.nocookie.net/harrypotter/images/3/34/Hermione_Granger.jpg/revision/latest/scale-to-width-down/1000?cb=20210522145306"
                        },
                        new
                        {
                            Id = 7,
                            Alias = "Thorongil",
                            FullName = "Aragorn II Elessar",
                            Gender = "Man",
                            ImageUrl = "https://static.wikia.nocookie.net/lotr/images/b/b6/Aragorn_profile.jpg/revision/latest?cb=20170121121423"
                        },
                        new
                        {
                            Id = 8,
                            Alias = "Old Greybeard",
                            FullName = "Gandalf",
                            Gender = "Man",
                            ImageUrl = "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest/scale-to-width-down/952?cb=20121110131754"
                        });
                });

            modelBuilder.Entity("MovieStoreWebApi.Models.Domain.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Harry Potter is a film series based on the eponymous novels by J. K. Rowling. The series is distributed by Warner Bros. and consists of eight fantasy films, beginning with Harry Potter and the Philosopher's Stone (2001) and culminating with Harry Potter and the Deathly Hallows – Part 2 (2011).",
                            Name = "Harry Potter"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The Marvel Cinematic Universe (MCU) is an American media franchise and shared universe centered on a series of superhero films produced by Marvel Studios. The films are based on characters that appear in American comic books published by Marvel Comics. The franchise also includes television series, short films, digital series, and literature.",
                            Name = "Marvel Cinematic Universe"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The DC Extended Universe is a collection of interconnected films and other media based on characters that appear in publications by DC Comics. The universe largely spans through films, though is touched on in many other mediums including comics, novels, guidebooks, short films, and video games.",
                            Name = "DC Extended Universe"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The Lord of the Rings is an epic high fantasy novel written by J.R.R. Tolkien, which was later fitted as a trilogy. The story began as a sequel to Tolkien's earlier fantasy book The Hobbit, and soon developed into a much larger story.",
                            Name = "Lord of the Rings"
                        });
                });

            modelBuilder.Entity("MovieStoreWebApi.Models.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ReleaseYear")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrailerUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Chris Columbus",
                            FranchiseId = 1,
                            Genre = "Adventure, Family, Fantasy",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/7a/Harry_Potter_and_the_Philosopher%27s_Stone_banner.jpg",
                            ReleaseYear = 2001,
                            Title = "Harry Potter and the Philosopher's Stone",
                            TrailerUrl = "https://www.youtube.com/watch?v=VyHV0BRtdxo"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Alfonso Cuarón",
                            FranchiseId = 1,
                            Genre = "Adventure, Family, Fantasy",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bc/Prisoner_of_azkaban_UK_poster.jpg",
                            ReleaseYear = 2004,
                            Title = "Harry Potter and the Prisoner of Azkaban",
                            TrailerUrl = "https://www.youtube.com/watch?v=1ZdlAg3j8nI"
                        },
                        new
                        {
                            Id = 3,
                            Director = "David Yates",
                            FranchiseId = 1,
                            Genre = "Adventure, Family, Fantasy",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/e/e7/Harry_Potter_and_the_Order_of_the_Phoenix_poster.jpg",
                            ReleaseYear = 2007,
                            Title = "Harry Potter and the Order of the Phoenix",
                            TrailerUrl = "https://www.youtube.com/watch?v=y6ZW7KXaXYk"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Jon Watts",
                            FranchiseId = 2,
                            Genre = "Action, Superhero",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/Spider-Man_Far_From_Home_poster.jpg",
                            ReleaseYear = 2019,
                            Title = "Spider-Man: Far From Home",
                            TrailerUrl = "https://www.youtube.com/watch?v=Nt9L1jCKGnE"
                        },
                        new
                        {
                            Id = 5,
                            Director = "Anna Boden",
                            FranchiseId = 2,
                            Genre = "Action, Superhero",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/4/4e/Captain_Marvel_%28film%29_poster.jpg",
                            ReleaseYear = 2019,
                            Title = "Captain Marvel",
                            TrailerUrl = "https://www.youtube.com/watch?v=Z1BCujX3pw8"
                        },
                        new
                        {
                            Id = 6,
                            Director = "Zack Snyder",
                            FranchiseId = 3,
                            Genre = "Adventure, Action, Superhero",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/Man_of_Steel_%28film%29_poster.jpg",
                            ReleaseYear = 2013,
                            Title = "Man of Steel",
                            TrailerUrl = "https://www.youtube.com/watch?v=T6DJcgm3wNY"
                        },
                        new
                        {
                            Id = 7,
                            Director = "James Gunn",
                            FranchiseId = 3,
                            Genre = "Adventure, Action, Superhero",
                            ImageUrl = "https://en.wikipedia.org/wiki/The_Suicide_Squad_(film)#/media/File:The_Suicide_Squad_(film)_poster.jpg",
                            ReleaseYear = 2021,
                            Title = "The Suicide Squad",
                            TrailerUrl = "https://www.youtube.com/watch?v=JuDLepNa7hw"
                        },
                        new
                        {
                            Id = 8,
                            Director = "Peter Jackson",
                            FranchiseId = 4,
                            Genre = "Adventure, Fantasy",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d0/Lord_of_the_Rings_-_The_Two_Towers_%282002%29.jpg",
                            ReleaseYear = 2002,
                            Title = "The Lord of the Rings: The Two Towers",
                            TrailerUrl = "https://www.youtube.com/watch?v=LbfMDwc4azU"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("MovieStoreWebApi.Models.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStoreWebApi.Models.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieStoreWebApi.Models.Domain.Movie", b =>
                {
                    b.HasOne("MovieStoreWebApi.Models.Domain.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MovieStoreWebApi.Models.Domain.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}