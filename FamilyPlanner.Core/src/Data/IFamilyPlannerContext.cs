using FamilyPlanner.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner.Core.Data;

public interface IFamilyPlannerContext
{
	void Migrate();
	DbSet<Recipe> Recipes { get; }
	DbSet<Tag> Tags { get; }
}