using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test1.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BinarySign = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesBranches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompaniesBranches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BinarySign", "Name" },
                values: new object[,]
                {
                    { -5, true, "Company5" },
                    { -4, true, "Company4" },
                    { -3, true, "Company3" },
                    { -2, false, "Company2" },
                    { -1, false, "Company1" }
                });

            migrationBuilder.InsertData(
                table: "CompaniesBranches",
                columns: new[] { "Id", "CompanyId", "Name" },
                values: new object[,]
                {
                    { -8, -5, "C5_B1" },
                    { -7, -3, "C3_B4" },
                    { -6, -3, "C3_B3" },
                    { -5, -3, "C3_B2" },
                    { -4, -3, "C3_B1" },
                    { -3, -2, "C2_B1" },
                    { -2, -1, "C1_B2" },
                    { -1, -1, "C1_B1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompaniesBranches_CompanyId",
                table: "CompaniesBranches",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompaniesBranches");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
