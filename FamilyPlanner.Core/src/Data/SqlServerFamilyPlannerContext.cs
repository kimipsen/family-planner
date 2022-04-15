using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner.Core.Data;

public class SqlServerFamilyPlannerContext : FamilyPlannerContext
{
	public SqlServerFamilyPlannerContext(DbContextOptions<FamilyPlannerContext> options) : base(options)
	{

	}
}