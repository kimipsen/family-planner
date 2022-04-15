using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyPlanner.Core.Data.Migrations
{
    public partial class IsoDayOfWeekAsArray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WeekDays",
                table: "FoodPlans",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WeekDays",
                table: "FoodPlans",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
