using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace blanchard_web_api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInSecond = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "ArtistName", "DurationInSecond", "Title" },
                values: new object[,]
                {
                    { 1, "David Bowie", 202, "Life On Mars?" },
                    { 2, "Manau", 285, "La tribu de Dana" },
                    { 3, "Jean-Jacques Goldman", 237, "Au bout de mes rêves" },
                    { 4, "Indochine", 326, "La vie est belle" },
                    { 5, "Florian Montagne", 122, "Moi, je viens de Narbonne" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
