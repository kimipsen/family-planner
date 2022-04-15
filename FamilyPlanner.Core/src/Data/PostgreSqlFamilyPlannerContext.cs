using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner.Core.Data;

public class PostgreSqlFamilyPlannerContext : FamilyPlannerContext
{
	public PostgreSqlFamilyPlannerContext(DbContextOptions<FamilyPlannerContext> options) : base(options)
	{

	}
}
