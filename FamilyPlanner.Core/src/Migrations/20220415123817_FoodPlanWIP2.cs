using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace FamilyPlanner.Core.Data.Migrations
{
    public partial class FoodPlanWIP2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<LocalDate>(
                name: "EndDate",
                table: "FoodPlans",
                type: "date",
                nullable: true,
                oldClrType: typeof(LocalDate),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<LocalDate>(
                name: "EndDate",
                table: "FoodPlans",
                type: "date",
                nullable: false,
                defaultValue: new NodaTime.LocalDate(1, 1, 1),
                oldClrType: typeof(LocalDate),
                oldType: "date",
                oldNullable: true);
        }
    }
}
