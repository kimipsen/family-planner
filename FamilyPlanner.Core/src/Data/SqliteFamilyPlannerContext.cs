using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner.Core.Data;

public class SqliteFamilyPlannerContext : FamilyPlannerContext
{
	public SqliteFamilyPlannerContext(DbContextOptions<FamilyPlannerContext> options) : base(options)
	{

	}
}
