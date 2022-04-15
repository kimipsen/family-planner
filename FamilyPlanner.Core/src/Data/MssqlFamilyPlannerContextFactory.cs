using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FamilyPlanner.Core.Data;

public class MssqlFamilyPlannerContextFactory : IDesignTimeDbContextFactory<MssqlFamilyPlannerContext>
{
	public MssqlFamilyPlannerContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>();
		optionsBuilder.UseSqlServer("Server=localhost;Database=familyplanner;User Id=familyplanner;Password=familyplanner;");

		return new MssqlFamilyPlannerContext(optionsBuilder.Options);
	}

	public MssqlFamilyPlannerContext CreateDbContext(string connectionString)
	{
		var optionsBuilder = new DbContextOptionsBuilder<FamilyPlannerContext>()
			.UseSqlServer(
				connectionString,
				b => b.MigrationsAssembly("FamilyPlanner.Core"));
		return new MssqlFamilyPlannerContext(optionsBuilder.Options);
	}
}