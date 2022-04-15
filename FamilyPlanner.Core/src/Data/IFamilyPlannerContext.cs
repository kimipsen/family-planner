using FamilyPlanner.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner.Core.Data;

public interface IFamilyPlannerContext
{
	void Migrate();
	int SaveChanges();
	DbSet<Recipe> Recipes { get; }
	DbSet<Tag> Tags { get; }
}