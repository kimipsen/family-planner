using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyPlanner.Core.Data.Migrations
{
    public partial class TagPupose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Purpose",
                table: "Tags",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Tags");
        }
    }
}
