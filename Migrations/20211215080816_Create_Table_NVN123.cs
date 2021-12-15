using Microsoft.EntityFrameworkCore.Migrations;

namespace NVN123.Migrations
{
    public partial class Create_Table_NVN123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NVN",
                columns: table => new
                {
                    NVNID = table.Column<string>(type: "TEXT", nullable: false),
                    NVNName = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVN", x => x.NVNID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NVN");
        }
    }
}
