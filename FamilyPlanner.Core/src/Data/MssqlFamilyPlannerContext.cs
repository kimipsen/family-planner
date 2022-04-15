using Microsoft.EntityFrameworkCore;

namespace FamilyPlanner.Core.Data;

public class MssqlFamilyPlannerContext : FamilyPlannerContext
{
	public MssqlFamilyPlannerContext(DbContextOptions<FamilyPlannerContext> options) : base(options)
	{

	}
}