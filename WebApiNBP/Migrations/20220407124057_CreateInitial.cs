using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiNBP.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pozycje",
                columns: table => new
                {
                    Nazwa_waluty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Przelicznik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kod_waluty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kurs_sredni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pozycje");
        }
    }
}
