using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oopkr.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    surname = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Boller",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    inWork = table.Column<bool>(type: "INTEGER", nullable: false),
                    generatePower = table.Column<int>(type: "INTEGER", nullable: false),
                    consumptionPower = table.Column<int>(type: "INTEGER", nullable: false),
                    Plantid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boller", x => x.id);
                    table.ForeignKey(
                        name: "FK_Boller_Plant_Plantid",
                        column: x => x.Plantid,
                        principalTable: "Plant",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boller_Plantid",
                table: "Boller",
                column: "Plantid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boller");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Plant");
        }
    }
}
