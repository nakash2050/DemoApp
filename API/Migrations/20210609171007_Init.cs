using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Designation = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmployees");
        }
    }
}
