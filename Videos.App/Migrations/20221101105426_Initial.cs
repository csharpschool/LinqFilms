using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Videos.App.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_FilmGenre_Films_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "The Shawshank Redemption", 1994 },
                    { 2, "The Godfather", 1972 },
                    { 3, "The Dark Knight", 2008 },
                    { 4, "Forrest Gump", 1994 },
                    { 5, "LOTR: The Return of the King", 2003 },
                    { 6, "LOTR: The Two Towers", 2002 },
                    { 7, "LOTR: The Fellowship of the Ring", 2001 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Fantasy" },
                    { 3, "Adventure" },
                    { 4, "Crime" },
                    { 5, "Romance" },
                    { 6, "Drama" },
                    { 7, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "FilmGenre",
                columns: new[] { "FilmsId", "GenresId" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 2, 6 },
                    { 2, 4 },
                    { 3, 6 },
                    { 3, 4 },
                    { 3, 1 },
                    { 4, 6 },
                    { 4, 5 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 6 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 6 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenresId",
                table: "FilmGenre",
                column: "GenresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
