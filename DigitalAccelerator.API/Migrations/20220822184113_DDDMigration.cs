using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalAccelerator.API.Migrations
{
    public partial class DDDMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Author", "Content" },
                values: new object[,]
                {
                    { 1, "Megan", "Test Note Content 1" },
                    { 2, "Taylor", "Test Note Content 2" },
                    { 3, "Benito", "Test Note Content 3" },
                    { 4, "Tim", "Test Note Content 4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
