using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieStoreWebApi.Migrations
{
    public partial class FixedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 7,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 8,
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/0/06/The_Suicide_Squad_%28film%29_poster.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 7,
                column: "Gender",
                value: "Man");

            migrationBuilder.UpdateData(
                table: "Character",
                keyColumn: "Id",
                keyValue: 8,
                column: "Gender",
                value: "Man");

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://en.wikipedia.org/wiki/The_Suicide_Squad_(film)#/media/File:The_Suicide_Squad_(film)_poster.jpg");
        }
    }
}
