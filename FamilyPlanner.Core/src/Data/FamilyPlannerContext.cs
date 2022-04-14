using FamilyPlanner.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner.Core.Data;

public class FamilyPlannerContext : DbContext, IFamilyPlannerContext
{
	public FamilyPlannerContext(DbContextOptions<FamilyPlannerContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// modelBuilder.Entity<Course>().ToTable("Course");
	}

	public void Migrate() => Database.Migrate();

	public DbSet<Tag> Tags { get; set; }
	public DbSet<Recipe> Recipes { get; set; }
}