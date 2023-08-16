using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftUniBazar.Migrations
{
    public partial class FixedColumnNameOfCreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateOn",
                table: "Ads",
                newName: "CreatedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Ads",
                newName: "CreateOn");
        }
    }
}
