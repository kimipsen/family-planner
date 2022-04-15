using FamilyPlanner.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;

namespace FamilyPlanner.Core.Data;

public class FamilyPlannerContext : DbContext
{
	public FamilyPlannerContext(DbContextOptions<FamilyPlannerContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// modelBuilder.Entity<Course>().ToTable("Course");
		modelBuilder.Entity<FoodPlan>()
			.Property(e => e.WeekDays)
			.HasConversion(IsoDayOfWeekArrayValueConverter);
	}

	public void Migrate() => Database.Migrate();

	public DbSet<Tag> Tags { get; set; }
	public DbSet<Recipe> Recipes { get; set; }
	public DbSet<FoodPlan> FoodPlans { get; set; }

	private ValueConverter<IsoDayOfWeek[], string> IsoDayOfWeekArrayValueConverter = new ValueConverter<IsoDayOfWeek[], string>(
		v => string.Join(";", v),
		v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => (IsoDayOfWeek)Enum.Parse<IsoDayOfWeek>(val)).ToArray()
	);
}