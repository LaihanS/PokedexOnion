using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    idregion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.idregion);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    idtipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.idtipo);
                });

            migrationBuilder.CreateTable(
                name: "Pokemones",
                columns: table => new
                {
                    idpoke = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idtipo = table.Column<int>(type: "int", nullable: false),
                    subtipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idRegion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemones", x => x.idpoke);
                    table.ForeignKey(
                        name: "FK_Pokemones_Regiones_idRegion",
                        column: x => x.idRegion,
                        principalTable: "Regiones",
                        principalColumn: "idregion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_Tipos_idtipo",
                        column: x => x.idtipo,
                        principalTable: "Tipos",
                        principalColumn: "idtipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_idRegion",
                table: "Pokemones",
                column: "idRegion");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_idtipo",
                table: "Pokemones",
                column: "idtipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemones");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
