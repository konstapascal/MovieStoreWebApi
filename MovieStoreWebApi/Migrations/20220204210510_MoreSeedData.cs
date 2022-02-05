using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStoreWebApi.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Franchise",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Alias", "FullName", "Gender", "ImageUrl" },
                values: new object[] { "Captain Marvel", "Carol Susan Jane Danvers", "Female", "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/f/fe/CapMarvel-EndgameProfile.jpeg/revision/latest?cb=20190423175247" });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Alias", "FullName", "Gender", "ImageUrl" },
                values: new object[] { "Batman", "Bruce Wayne", "Male", "https://static.wikia.nocookie.net/marvel_dc/images/7/76/Batman_Urban_Legends_Vol_1_5_Textless.jpg/revision/latest?cb=20210717062920" });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Alias", "FullName", "Gender", "ImageUrl" },
                values: new object[] { "The Joker", "Unknown", "Male", "https://static.wikia.nocookie.net/marvel_dc/images/5/5d/Doomsday_Clock_Vol_1_5_Textless_Variant.jpg/revision/latest?cb=20180606215837" });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "ImageUrl" },
                values: new object[,]
                {
                    { 5, "The Chosen One", "Harry James Potter", "Male", "https://static.wikia.nocookie.net/harrypotter/images/9/97/Harry_Potter.jpg/revision/latest/scale-to-width-down/360?cb=20140603201724" },
                    { 6, "Harry Potter (under disguise of Polyjuice Potion)", "Hermione Jean Granger", "Female", "https://static.wikia.nocookie.net/harrypotter/images/3/34/Hermione_Granger.jpg/revision/latest/scale-to-width-down/1000?cb=20210522145306" },
                    { 7, "Thorongil", "Aragorn II Elessar", "Man", "https://static.wikia.nocookie.net/lotr/images/b/b6/Aragorn_profile.jpg/revision/latest?cb=20170121121423" },
                    { 8, "Old Greybeard", "Gandalf", "Man", "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest/scale-to-width-down/952?cb=20121110131754" }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Harry Potter is a film series based on the eponymous novels by J. K. Rowling. The series is distributed by Warner Bros. and consists of eight fantasy films, beginning with Harry Potter and the Philosopher's Stone (2001) and culminating with Harry Potter and the Deathly Hallows – Part 2 (2011).", "Harry Potter" });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "The Marvel Cinematic Universe (MCU) is an American media franchise and shared universe centered on a series of superhero films produced by Marvel Studios. The films are based on characters that appear in American comic books published by Marvel Comics. The franchise also includes television series, short films, digital series, and literature.", "Marvel Cinematic Universe" });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "The DC Extended Universe is a collection of interconnected films and other media based on characters that appear in publications by DC Comics. The universe largely spans through films, though is touched on in many other mediums including comics, novels, guidebooks, short films, and video games.");

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, "The Lord of the Rings is an epic high fantasy novel written by J.R.R. Tolkien, which was later fitted as a trilogy. The story began as a sequel to Tolkien's earlier fantasy book The Hobbit, and soon developed into a much larger story.", "Lord of the Rings" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Director", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { "Chris Columbus", "Adventure, Family, Fantasy", "https://upload.wikimedia.org/wikipedia/en/7/7a/Harry_Potter_and_the_Philosopher%27s_Stone_banner.jpg", 2001, "Harry Potter and the Philosopher's Stone", "https://www.youtube.com/watch?v=VyHV0BRtdxo" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Director", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { "Alfonso Cuarón", "Adventure, Family, Fantasy", "https://upload.wikimedia.org/wikipedia/en/b/bc/Prisoner_of_azkaban_UK_poster.jpg", 2004, "Harry Potter and the Prisoner of Azkaban", "https://www.youtube.com/watch?v=1ZdlAg3j8nI" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Director", "FranchiseId", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { "David Yates", 1, "Adventure, Family, Fantasy", "https://upload.wikimedia.org/wikipedia/en/e/e7/Harry_Potter_and_the_Order_of_the_Phoenix_poster.jpg", 2007, "Harry Potter and the Order of the Phoenix", "https://www.youtube.com/watch?v=y6ZW7KXaXYk" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Director", "FranchiseId", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { "Jon Watts", 2, "Action, Superhero", "https://upload.wikimedia.org/wikipedia/en/b/bd/Spider-Man_Far_From_Home_poster.jpg", 2019, "Spider-Man: Far From Home", "https://www.youtube.com/watch?v=Nt9L1jCKGnE" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Director", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { "Anna Boden", "Action, Superhero", "https://upload.wikimedia.org/wikipedia/en/4/4e/Captain_Marvel_%28film%29_poster.jpg", 2019, "Captain Marvel", "https://www.youtube.com/watch?v=Z1BCujX3pw8" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 7, "James Gunn", 3, "Adventure, Action, Superhero", "https://en.wikipedia.org/wiki/The_Suicide_Squad_(film)#/media/File:The_Suicide_Squad_(film)_poster.jpg", 2021, "The Suicide Squad", "https://www.youtube.com/watch?v=JuDLepNa7hw" },
                    { 6, "Zack Snyder", 3, "Adventure, Action, Superhero", "https://upload.wikimedia.org/wikipedia/en/5/50/Man_of_Steel_%28film%29_poster.jpg", 2013, "Man of Steel", "https://www.youtube.com/watch?v=T6DJcgm3wNY" }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 2 },
                    { 6, 3 },
                    { 4, 7 }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { 8, "Peter Jackson", 4, "Adventure, Fantasy", "https://upload.wikimedia.org/wikipedia/en/d/d0/Lord_of_the_Rings_-_The_Two_Towers_%282002%29.jpg", 2002, "The Lord of the Rings: The Two Towers", "https://www.youtube.com/watch?v=LbfMDwc4azU" });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[] { 7, 8 });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[] { 8, 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Franchise",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Alias", "FullName", "Gender", "ImageUrl" },
                values: new object[] { "Batman", "Bruce Wayne", "Male", "https://static.wikia.nocookie.net/marvel_dc/images/7/76/Batman_Urban_Legends_Vol_1_5_Textless.jpg/revision/latest?cb=20210717062920" });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Alias", "FullName", "Gender", "ImageUrl" },
                values: new object[] { "Captain Marvel", "Carol Susan Jane Danvers", "Woman", "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/f/fe/CapMarvel-EndgameProfile.jpeg/revision/latest?cb=20190423175247" });

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Alias", "FullName", "Gender", "ImageUrl" },
                values: new object[] { "Superman", "Clark Kent", "Man", "https://static.wikia.nocookie.net/marvel_dc/images/a/a5/Superman_Vol_5_1_Textless.jpg/revision/latest?cb=20180711061148" });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description for MCU", "Marvel Cinematic Universe" });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description for MCU 2", "Marvel Cinematic Universe 2" });

            migrationBuilder.UpdateData(
                table: "Franchise",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Description for DCEU");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Director", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { null, "Action, Drama", null, 2002, "Movie 1", null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Director", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { null, "Action, Drama", null, 1996, "Movie 2", null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Director", "FranchiseId", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { null, 3, "Action, Drama, Romance", null, 2006, "Movie 3", null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Director", "FranchiseId", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { null, 3, "Action, Drama, Comedy", null, 2011, "Movie 4", null });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Director", "Genre", "ImageUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[] { null, "Action, Drama", null, 2020, "Movie 5", null });
        }
    }
}
